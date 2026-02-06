using Backend.Infra.Api.ChangeRecord;
using Backend.Infra.Api.ChangeRecord.DTO;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Identity.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Controllers.Interfaces
{
    public interface IChangeRecordTrackerController
        : IIdentityController<ChangeRecordTrackerController, ChangeRecordTrackerHandler, IdentityDbContext, ChangeRecordTracker, ChangeRecordTrackerDTO>,
        IBaseControllerCrud<ChangeRecordTrackerController, ChangeRecordTrackerHandler, IdentityDbContext, ChangeRecordTracker, ChangeRecordTrackerDTO>
    {
        Task<IActionResult> Fetch();
        Task<IActionResult> FetchById([FromBody] FetchById filtro);
        Task<IActionResult> FetchByName([FromBody] FetchByName filtro);
    }
}
