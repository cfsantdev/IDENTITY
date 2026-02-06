namespace Backend.Infra.Identity.Session
{
    public class CreateSession : Interfaces.Session.ICreate
    {
        public Guid? OwnerId { get; set; }
        public string Token { get; set; }
    }
}
