using Backend.Infra.Api.Crud.Interfaces;

namespace Backend.Infra.Identity.Interfaces.Profile
{
    public interface IUpdateProfile : IUpdate
    {
        string Password { get; set; }
    }
}
