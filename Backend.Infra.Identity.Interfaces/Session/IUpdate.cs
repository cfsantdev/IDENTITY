namespace Backend.Infra.Identity.Interfaces.Session
{
    public interface IUpdate
    {
        Guid? OwnerId { get; set; }
        Guid? PublisherId { get; set; }
        string Token { get; set; }
    }
}
