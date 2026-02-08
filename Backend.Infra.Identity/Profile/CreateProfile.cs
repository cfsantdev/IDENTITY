using Backend.Infra.Identity.Interfaces.Profile;

namespace Backend.Infra.Identity.Profile
{
    public class CreateProfile : Api.Crud.Create, ICreate
    {
        public string? Email { get; set; }
        public Guid? OwnerId { get; set; }
        public string? Password { get; set; }
        public string[]? Role { get; set; }
    }
}
