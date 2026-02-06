using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.DTO.Session;
using Backend.Infra.Identity.Session;
using Identity.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Handlers.Interfaces
{
    public interface ISessionHandler
        : IIdentityHandler<SessionController, IdentityDbContext, Session, SessionDTO>,
        IBaseHandlerCrud<SessionController, IdentityDbContext, Session, SessionDTO>
    {
        new Task<IActionResult> FetchAsync();
        new Task<IActionResult> FetchByIdAsync(IFetchById filtro);
        new Task<IActionResult> DeleteByIdAsync(IFetchById filtro);

        Task<IActionResult> FetchByTokenAsync(IFetchByToken filtro);
        Task<IActionResult> CreateAsync(CreateSession registry);
        Task<IActionResult> UpdateAsync(UpdateSession registry);
        Task<IActionResult> DeleteByTokenAsync(IFetchByToken filtro);
    }
}
