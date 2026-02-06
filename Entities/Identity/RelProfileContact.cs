using Entities.Public.Interfaces;
using Entities.Catalog.Interfaces;
using Entities.Identity.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Identity
{
    public class RelProfileContact : IRelProfileContact
    {
        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }
        [ForeignKey("Contact")]
        public Guid ContactId { get; set; }

        public virtual IProfile Profile { get; set; }
        public virtual IContact Contact { get; set; }
    }
}
