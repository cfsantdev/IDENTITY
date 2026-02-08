using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Identity.Interfaces.Profile
{
    public interface IProfile : IBaseNamedStateful
    {
        string? Email { get; set; }
        string? Password { get; set; }
        string[]? Role { get; set; }
    }
}
