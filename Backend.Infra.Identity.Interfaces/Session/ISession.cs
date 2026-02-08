using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Identity.Interfaces.Session
{
    public interface ISession : IBase
    {
        string Token { get; set; }
    }
}
