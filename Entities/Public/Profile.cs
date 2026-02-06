using Entities.Public.Interfaces;

namespace Entities.Public
{
    public class Profile : BaseNamedStateful, IProfile
    {
        public string Password { get; set; }
        public string[] Role { get; set; }
    }
}
