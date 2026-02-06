using Entities.Public.Interfaces;
using Entities.Identity.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Identity
{
    public class RelProfileDocument : IRelProfileDocument
    {
        [ForeignKey("Document")]
        public Guid DocumentId { get; set; }
        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }

        public IDocument Document { get; set; }
        public IProfile Profile { get; set; }
    }
}
