using Backend.Infra.Identity.DTO.Interfaces.Profile;

namespace Backend.Infra.Identity.DTO.Profile
{
    public class ProfileAuthenticateDTO : IProfileAuthenticateDTO
    {
        public string? Token { get; set; }
    }
}
