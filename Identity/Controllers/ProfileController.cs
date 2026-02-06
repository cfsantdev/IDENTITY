using AutoMapper;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Exceptions.Internal;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.DTO.Profile;
using Backend.Infra.Identity.Profile;
using Backend.Infra.Middlewares;
using Identity.Controllers.Interfaces;
using Identity.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Profile = Backend.Infra.Identity.Profile.Profile;

namespace Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(AuthenticationManagementMiddleware))]
    public class ProfileController 
        : IdentityController<ProfileController, ProfileHandler, IdentityDbContext, Profile, ProfileDTO>,
        IIdentityController<ProfileController, ProfileHandler, IdentityDbContext, Profile, ProfileDTO>,
        IBaseControllerCrud<ProfileController, ProfileHandler, IdentityDbContext, Profile, ProfileDTO>,
        IProfileController
    {
        public ProfileController(ILogger<ProfileController> logger, IdentityDbContext context, IMapper mapper) 
            : base(logger, context, mapper)
        {
        }

        [HttpGet("SelfSign")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SelfSign()
        {
            try
            {
                return await this._handler.SelfSignAsync(HttpContext);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ProfileController, Exception>(nameof(SelfSign), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileAuthenticateDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Authenticate([FromBody] Authentication auth)
        {
            try
            {
                return await this._handler.AuthenticateAsync(auth);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ProfileController, Exception>(nameof(Authenticate), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpGet("Fetch")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfileDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Fetch()
        {
            try
            {
                return await this._handler.FetchAsync();
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ProfileController, Exception>(nameof(Fetch), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("FetchById")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchById([FromBody] FetchById filtro)
        {
            try
            {
                return await this._handler.FetchByIdAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ProfileController, Exception>(nameof(FetchById), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("FetchByName")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchByName([FromBody] FetchByName filtro)
        {
            try
            {
                return await this._handler.FetchByNameAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ProfileController, Exception>(nameof(FetchByName), ex)){
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] CreateProfile registry)
        {
            try
            {
                return await this._handler.CreateAsync(registry);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ProfileController, Exception>(nameof(Create), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
            
        }

        [HttpPut("Update")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateProfile registry)
        {
            try
            {
                return await this._handler.UpdateAsync(registry);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ProfileController, Exception>(nameof(Update), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPut("ChangeStatus")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeStatus([FromBody] FetchById filtro)
        {
            try
            {
                return await this._handler.ChangeStateByIdAsync((IFetchById)filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ProfileController, Exception>(nameof(ChangeStatus), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
            
        }

    }
}
