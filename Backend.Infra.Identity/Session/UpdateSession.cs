namespace Backend.Infra.Identity.Session
{
    public class UpdateSession : Backend.Infra.Identity.Interfaces.Session.IUpdate
    {
        public Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public string Token { get; set; }
    }
}
