using Backend.Infra.Identity.Interfaces.Profile;

namespace Backend.Infra.Identity.Profile
{
    public class Authentication : IAuthentication
    {
        public string? Hash { get; set; }
    }
}
