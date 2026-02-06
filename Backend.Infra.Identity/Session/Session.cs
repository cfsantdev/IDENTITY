using Backend.Infra.Identity.Interfaces.Session;

namespace Backend.Infra.Identity.Session
{
    public class Session : Base.Base, ISession
    {
        public string Token { get; set; }
    }
}
