using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.DTO.Session;
using Backend.Infra.Identity.Session;
using Identity.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Controllers.Interfaces
{
    public interface ISessionController
        : IIdentityController<SessionController, SessionHandler, IdentityDbContext, Session, SessionDTO>,
        IBaseControllerCrud<SessionController, SessionHandler, IdentityDbContext, Session, SessionDTO>
    {
        Task<IActionResult> Fetch();
        Task<IActionResult> FetchById([FromBody] FetchById filtro);
        Task<IActionResult> FetchByToken([FromBody] FetchByToken filtro);
        Task<IActionResult> Create([FromBody] CreateSession registry);
        Task<IActionResult> Update([FromBody] UpdateSession registry);
        Task<IActionResult> DeleteById([FromBody] FetchById filtro);
        Task<IActionResult> DeleteByToken([FromBody] FetchByToken filtro);
    }
}
