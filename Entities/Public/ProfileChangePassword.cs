using System;

namespace Entities.Public
{
    public class ProfileChangePassword
    {
        public Guid? Id { get; set; }
        public Guid? PublisherId { get; set; }
        public string Password { get; set; }
    }
}
