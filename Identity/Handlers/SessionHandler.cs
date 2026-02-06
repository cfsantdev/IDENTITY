using AutoMapper;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.DTO.Session;
using Backend.Infra.Identity.Session;
using Identity.Controllers;
using Identity.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Identity.Handlers
{
    public class SessionHandler : IdentityHandler<SessionController, IdentityDbContext, Session, SessionDTO>,
        IIdentityHandler<SessionController, IdentityDbContext, Session, SessionDTO>,
        IBaseHandlerCrud<SessionController, IdentityDbContext, Session, SessionDTO>,
        ISessionHandler
    {

        public SessionHandler(ILogger<SessionController> logger, IdentityDbContext context, IMapper mapper) :
            base(logger,
                context,
                mapper,
                context.PUBLISHER_SETTINGS.DocumentPublisher
            )
        {
        }

        new async Task<IActionResult> FetchAsync() => await base.FetchAsync();
        new async Task<IActionResult> FetchByIdAsync(IFetchById filtro) => await base.FetchByIdAsync(filtro);
        new async Task<IActionResult> DeleteByIdAsync(IFetchById filtro) => await base.DeleteByIdAsync(filtro);

        public async Task<IActionResult> FetchByTokenAsync(IFetchByToken filtro)
        {
            Session result = await _context.Session.SingleOrDefaultAsync(x => x.Token == filtro.Token);
            if (result == null || result == default)
            {
                return NotFound($"The '{typeof(Session).Name}' not found. \nReview the information and resend the request, if the problem persists, contact support via email:");
            }

            var dto = _mapper.Map<SessionDTO>(result);
            if (dto == null || dto == default)
            {
                return Problem($"Casting error from {nameof(SessionDTO)}.");
            }

            return Ok(dto);
        }
        public async Task<IActionResult> CreateAsync(CreateSession registry) => await base.CreateAsync(registry);
        public async Task<IActionResult> UpdateAsync(UpdateSession registry) => await base.UpdateAsync(registry);
        public async Task<IActionResult> DeleteByTokenAsync(IFetchByToken filtro)
        {
            Session entity = await _context.Session.SingleOrDefaultAsync(x => x.Token == filtro.Token);
            if (entity == null || entity == default)
            {
                return NotFound("The 'SESSION' not found. \nReview the information and resend the request, if the problem persists, contact support via email:");
            }

            entity.PublisherId = Guid.Parse(this._context.PUBLISHER_SETTINGS.SessionPublisher);

            _context.Session.Remove(entity);

            int value = _context.SaveChanges();

            return Ok(value);
        }
    }
}
