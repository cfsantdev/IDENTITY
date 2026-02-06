using System;

namespace Entities.Identity.Req
{
    public class CreateSession
    {
        public Guid? OwnerId { get; set; }
        public string Token { get; set; }
    }
}
