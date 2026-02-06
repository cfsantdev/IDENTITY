namespace Backend.Infra.Identity.Interfaces.Session
{
    public interface ICreate
    {
        Guid? OwnerId { get; set; }
        string Token { get; set; }
    }
}
