using AutoMapper;
using Backend.Infra.Api.ChangeRecord.DTO;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Enumerators;
using Backend.Infra.Exceptions.Internal;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.DTO.Profile;
using Backend.Infra.Identity.DTO.Session;
using Backend.Infra.Identity.Session;
using Identity.Controllers.Interfaces;
using Identity.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : IdentityController<SessionController, SessionHandler, IdentityDbContext, Session, SessionDTO>,
        IIdentityController<SessionController, SessionHandler, IdentityDbContext, Session, SessionDTO>,
        IBaseControllerCrud<SessionController, SessionHandler, IdentityDbContext, Session, SessionDTO>,
        ISessionController
    {
        public SessionController(ILogger<SessionController> logger, IdentityDbContext context, IMapper mapper)
            : base(logger, context, mapper)
        {
        }

        [HttpGet("Fetch")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SessionDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Fetch()
        {
            try
            {
                return await this._handler.FetchAsync();
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<SessionController, Exception>(nameof(Fetch), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("FetchById")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SessionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchById([FromBody] FetchById filtro)
        {
            try
            {
                return await this._handler.FetchByIdAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<SessionController, Exception>(nameof(FetchById), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("FetchByToken")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SessionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchByToken([FromBody] FetchByToken filtro)
        {
            try
            {
                return await this._handler.FetchByTokenAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<SessionController, Exception>(nameof(FetchByToken), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("Create")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SessionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] CreateSession registry)
        {
            try
            {
                return await this._handler.CreateAsync(registry);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<SessionController, Exception>(nameof(Create), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPut("Update")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SessionDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateSession registry)
        {
            try
            {
                return await this._handler.UpdateAsync(registry);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<SessionController, Exception>(nameof(Update), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpDelete("DeleteById")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById([FromBody] FetchById filtro)
        {
            try
            {
                return await this._handler.DeleteByIdAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<SessionController, Exception>(nameof(DeleteById), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpDelete("DeleteByToken")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByToken([FromBody] FetchByToken filtro)
        {
            try
            {
                return await this._handler.DeleteByTokenAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<SessionController, Exception>(nameof(DeleteByToken), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }
    }
}
