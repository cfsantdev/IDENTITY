using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.DTO.Profile;
using Backend.Infra.Identity.Profile;
using Identity.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Controllers.Interfaces
{
    public interface IProfileController
        : IIdentityController<ProfileController, ProfileHandler, IdentityDbContext, Profile, ProfileDTO>,
        IBaseControllerCrud<ProfileController, ProfileHandler, IdentityDbContext, Profile, ProfileDTO>
    {
        Task<IActionResult> Authenticate([FromBody] Authentication auth);
        Task<IActionResult> Fetch();
        Task<IActionResult> FetchById([FromBody] FetchById filtro);
        Task<IActionResult> FetchByName([FromBody] FetchByName filtro);
        Task<IActionResult> Create([FromBody] CreateProfile registry);
        Task<IActionResult> Update([FromBody] UpdateProfile registry);
        Task<IActionResult> ChangeStatus([FromBody] FetchById filtro);
    }
}
