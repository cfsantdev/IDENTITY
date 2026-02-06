using Entities.Public;
using System;

namespace Entities.Identity.Req
{
    public class CreateProfile : Create
    {
        public Guid? OwnerId { get; set; }
        public string Password { get; set; }
        public string[] Role { get; set; }
    }
}
