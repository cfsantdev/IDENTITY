using Backend.Infra.Identity.DTO.Interfaces.Session;

namespace Backend.Infra.Identity.DTO.Session
{
    public class SessionDTO : ISessionDTO
    {
        public Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public DateTime? Insertion { get; set; }
        public DateTime? Change { get; set; }
        public string? Token { get; set; }
    }
}
