using AutoMapper;
using Backend.Infra.Api.ChangeRecord;
using Backend.Infra.Api.ChangeRecord.DTO;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Enumerators;
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
    public class ChangeRecordTrackerController : IdentityController<ChangeRecordTrackerController, ChangeRecordTrackerHandler, IdentityDbContext, ChangeRecordTracker, ChangeRecordTrackerDTO>,
        IIdentityController<ChangeRecordTrackerController, ChangeRecordTrackerHandler, IdentityDbContext, ChangeRecordTracker, ChangeRecordTrackerDTO>,
        IBaseControllerCrud<ChangeRecordTrackerController, ChangeRecordTrackerHandler, IdentityDbContext, ChangeRecordTracker, ChangeRecordTrackerDTO>,
        IChangeRecordTrackerController
    {
        public ChangeRecordTrackerController(ILogger<ChangeRecordTrackerController> logger, IdentityDbContext context, IMapper mapper) 
            : base(logger, context, mapper)
        {
        }

        [HttpGet("Fetch")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ChangeRecordTrackerDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Fetch()
        {
            try
            {
                return await this._handler.FetchAsync();
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ChangeRecordTrackerController, Exception>(nameof(Fetch), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("FetchById")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChangeRecordTrackerDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchById([FromBody] FetchById filtro)
        {
            try
            {
                return await this._handler.FetchByIdAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ChangeRecordTrackerController, Exception>(nameof(FetchById), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("FetchByName")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChangeRecordTrackerDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchByName([FromBody] FetchByName filtro)
        {
            try
            {
                return await this._handler.FetchByNameAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<ChangeRecordTrackerController, Exception>(nameof(FetchByName), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }
    }
}
