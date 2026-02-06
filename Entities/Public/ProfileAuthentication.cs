using Entities.Public.Interfaces;

namespace Entities.Public
{
    public class ProfileAuthentication : IProfileAuthentication
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
