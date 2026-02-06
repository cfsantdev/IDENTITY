using Backend.Infra.Identity.DTO.Interfaces.Profile;

namespace Backend.Infra.Identity.DTO.Profile
{
    public class ProfileDTO : IProfileDTO
    {
        public Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public string? Email { get; set; }
        public string[]? Role { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Hash { get; set; }
        public string? HashAuth { get; set; }
        public bool State { get; set; }
        public DateTime? Insertion { get; set; }
        public DateTime? Change { get; set; }
    }
}
