using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Identity.Req
{
    public class UpdateSession
    {
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public string Token { get; set; }
    }
}
