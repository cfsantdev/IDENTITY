using Backend.Infra.Api.Crud;
using Backend.Infra.Identity.Interfaces.Profile;

namespace Backend.Infra.Identity.Profile
{
    public class UpdateProfile : Update, IUpdateProfile
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
