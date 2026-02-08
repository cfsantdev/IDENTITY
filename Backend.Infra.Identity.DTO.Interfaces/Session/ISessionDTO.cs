namespace Backend.Infra.Identity.DTO.Interfaces.Session
{
    public interface ISessionDTO
    {
        Guid? Id { get; set; }
        Guid? OwnerId { get; set; }
        Guid? PublisherId { get; set; }
        DateTime? Insertion { get; set; }
        DateTime? Change { get; set; }
        string? Token { get; set; }
    }
}
