using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.DTO.Profile;
using Backend.Infra.Identity.Profile;
using Backend.Infra.Identity.Session;
using Identity.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Handlers.Interfaces
{
    public interface IProfileHandler
        : IIdentityHandler<ProfileController, IdentityDbContext, Profile, ProfileDTO>,
        IBaseHandlerCrud<ProfileController, IdentityDbContext, Profile, ProfileDTO>
    {
        new Task<IActionResult> FetchAsync();
        new Task<IActionResult> FetchByIdAsync(IFetchById filtro);
        new Task<IActionResult> FetchByNameAsync(IFetchByName filtro);

        Task<IActionResult> AuthenticateAsync(Authentication auth);
        Task<IActionResult> CreateAsync(CreateProfile registry);
        Task<IActionResult> UpdateAsync(UpdateProfile registry);
        Task<IActionResult> ChangeStateByIdAsync(FetchById filtro);

        void AuthenticateSubprocess(Profile profile, ref Session session);
    }
}
