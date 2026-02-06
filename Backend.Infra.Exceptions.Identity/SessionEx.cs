using Backend.Infra.Exceptions.Internal;
using Backend.Infra.Exceptions.Internal.Interfaces;

namespace Backend.Infra.Exceptions.Identity
{
    public class SessionEx : ExCollection, IExCollection
    {
        public SessionEx(string supportEmail) : base(supportEmail)
        {
            this.Add(new ExCItem("session", "create"));
        }
    }
}
