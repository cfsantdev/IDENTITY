namespace Backend.Infra.Identity.DTO.Interfaces.Profile
{
    public interface IProfileDTO
    {
        Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        string? Email { get; set; }
        string[]? Role { get; set; }
        string? Name { get; set; }
        string? Hash { get; set; }
        bool State { get; set; }
        public DateTime? Insertion { get; set; }
        public DateTime? Change { get; set; }
    }
}
