using Backend.Infra.Api.ChangeRecord;
using Backend.Infra.Api.ChangeRecord.DTO;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Identity.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Handlers.Interfaces
{
    public interface IChangeRecordHandler
        : IIdentityHandler<ChangeRecordController, IdentityDbContext, ChangeRecord, ChangeRecordDTO>,
        IBaseHandlerCrud<ChangeRecordController, IdentityDbContext, ChangeRecord, ChangeRecordDTO>
    {
        Task<IActionResult> UndoAsync(FetchById filtro);
    }
}
