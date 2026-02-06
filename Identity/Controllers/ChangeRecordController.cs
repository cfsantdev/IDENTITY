using AutoMapper;
using Backend.Infra.Api.ChangeRecord;
using Backend.Infra.Api.ChangeRecord.DTO;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Exceptions.Internal;
using Backend.Infra.Identity.DbContext;
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
    public class ChangeRecordController : IdentityController<ChangeRecordController, ChangeRecordHandler, IdentityDbContext, ChangeRecord, ChangeRecordDTO>,
        IIdentityController<ChangeRecordController, ChangeRecordHandler, IdentityDbContext, ChangeRecord, ChangeRecordDTO>,
        IBaseControllerCrud<ChangeRecordController, ChangeRecordHandler, IdentityDbContext, ChangeRecord, ChangeRecordDTO>,
        IChangeRecordController
    {
        public ChangeRecordController(ILogger<ChangeRecordController> logger, IdentityDbContext context, IMapper mapper) 
            : base(logger, context, mapper)
        {
        }

        [HttpGet("Fetch")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ChangeRecordDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Fetch()
        {
            try
            {
                return await this._handler.FetchAsync();
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ChangeRecordController, Exception>(nameof(Fetch), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("FetchById")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChangeRecordDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchById([FromBody] FetchById filtro)
        {
            try
            {
                return await this._handler.FetchByIdAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ChangeRecordController, Exception>(nameof(FetchById), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("FetchByName")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ChangeRecordDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchByName([FromBody] FetchByName filtro)
        {
            try
            {
                return await this._handler.FetchByNameAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ChangeRecordController, Exception>(nameof(FetchByName), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("Undo")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChangeRecordDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Undo([FromBody] FetchById filtro)
        {
            try
            {
                return await this._handler.UndoAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ChangeRecordController, Exception>(nameof(Undo), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }
    }
}
