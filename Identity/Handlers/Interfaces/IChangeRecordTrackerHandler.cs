using Backend.Infra.Api.ChangeRecord;
using Backend.Infra.Api.ChangeRecord.DTO;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Identity.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Handlers.Interfaces
{
    public interface IChangeRecordTrackerHandler
        : IIdentityHandler<ChangeRecordTrackerController, IdentityDbContext, ChangeRecordTracker, ChangeRecordTrackerDTO>,
        IBaseHandlerCrud<ChangeRecordTrackerController, IdentityDbContext, ChangeRecordTracker, ChangeRecordTrackerDTO>
    {
        new Task<IActionResult> FetchAsync();
        new Task<IActionResult> FetchByIdAsync(IFetchById filtro);
        new Task<IActionResult> FetchByNameAsync(IFetchByName filtro);
    }
}
