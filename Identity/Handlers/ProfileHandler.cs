using AutoMapper;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Enumerators;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.DTO.Profile;
using Backend.Infra.Identity.Profile;
using Backend.Infra.Identity.Session;
using Base.Infra.Cryptography;
using Identity.Controllers;
using Identity.Handlers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Profile = Backend.Infra.Identity.Profile.Profile;

namespace Identity.Handlers
{
    public class ProfileHandler 
        : IdentityHandler<ProfileController, IdentityDbContext, Profile, ProfileDTO>,
        IIdentityHandler<ProfileController, IdentityDbContext, Profile, ProfileDTO>,
        IBaseHandlerCrud<ProfileController, IdentityDbContext, Profile, ProfileDTO>,
        IProfileHandler
    {
        public ProfileHandler(ILogger<ProfileController> logger, IdentityDbContext context, IMapper mapper)
            : base(logger, 
                  context, 
                  mapper, 
                  context.PUBLISHER_SETTINGS.ProfilePublisher
            )
        {
        }

        new public async Task<IActionResult> FetchAsync() => await base.FetchAsync();
        new public async Task<IActionResult> FetchByIdAsync(IFetchById filtro) => await base.FetchByIdAsync(filtro);
        new public async Task<IActionResult> FetchByNameAsync(IFetchByName filtro) => await base.FetchByNameAsync(filtro);

        public async Task<IActionResult> SelfSignAsync(HttpContext httpContext)
        {
            string? authorization = httpContext.Request.Headers.Authorization.SingleOrDefault();
            if (string.IsNullOrEmpty(authorization) || string.IsNullOrWhiteSpace(authorization))
                return NotFound();

            string bearer = authorization.Replace("Bearer ", null);
            JwtSecurityToken? token = Backend.Infra.Token.Services.ReadToken(bearer);
            if (token == null || token == default)
                throw new Exception("Invalid token.");

            var claim = token.Claims.SingleOrDefault(x => x.Type.Equals(ClaimTypes.Hash));
            if (claim == null || claim == default)
                throw new Exception("Invalid claim.");

            var hash = claim.Value;
            if (string.IsNullOrEmpty(hash) || string.IsNullOrWhiteSpace(hash))
                throw new Exception("Invalid claim value.");

            Profile? profile = await _context.Profile.SingleOrDefaultAsync(x => x.HashAuth.Equals(hash));
            if (profile == null || profile == default)
                throw new Exception("Invalid profile.");

            ProfileDTO dto = _mapper.Map<Profile, ProfileDTO>(profile);
            if (dto == null || dto == default)
                return Problem($"Casting error from {nameof(List<ProfileDTO>)}.");

            return Ok(dto);
        }

        public async Task<IActionResult> AuthenticateAsync(Authentication auth)
        {
            Profile profile = null;
            Session session = null;

            try
            {
                var authB64 = Crypto.EncodeToBase64(auth.Hash.ToUpper());
                profile = await _context.Profile.Where(x => x.HashAuth.ToUpper() == authB64.ToUpper()).FirstOrDefaultAsync();
                session = await _context.Session.SingleOrDefaultAsync(x => x.OwnerId == profile.Id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            this.AuthenticateSubprocess(profile, ref session);

            int value = _context.SaveChanges();

            return Ok(new ProfileAuthenticateDTO
            {
                Token = session.Token
            });
        }

        public async Task<IActionResult> CreateAsync(CreateProfile registry)
        {
            if (registry.OwnerId == null || registry.OwnerId == Guid.Empty)
                registry.OwnerId = Guid.Parse(_context.PUBLISHER_SETTINGS.ProfilePublisher);

            if (registry.Role == null || registry.Role.Length < 1)
                registry.Role = new string[] { Roles.REGULAR };

            registry.Password = Crypto.EncodeToBase64(registry.Password);

            return await base.CreateAsync(registry);
        }

        public async Task<IActionResult> UpdateAsync(UpdateProfile registry) => await base.UpdateAsync(registry);

        public async Task<IActionResult> ChangeStateByIdAsync(FetchById filtro) => await base.ChangeStateByIdAsync(filtro);

        public void AuthenticateSubprocess(Profile profile, ref Session session)
        {
            bool update = false;

            if (session != null && session != default && session.Id != default)
            {
                update = true;
            }

            if (update)
            {
                session.Token = Backend.Infra.Token.Services.GenerateToken(profile);
                session.PublisherId = Guid.Parse(this._context.PUBLISHER_SETTINGS.SessionPublisher);
                session = _context.Session.Update(session)?.Entity;
            }
            else
            {
                session = _context.Session.Add(new Session()
                {
                    Token = Backend.Infra.Token.Services.GenerateToken(profile),
                    OwnerId = profile.Id,
                    PublisherId = Guid.Parse(this._context.PUBLISHER_SETTINGS.SessionPublisher)
                })?.Entity;
            }
        }
    }
}
