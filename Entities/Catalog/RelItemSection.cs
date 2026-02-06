using Entities.Catalog.Interfaces;
using Entities.Public;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Catalog
{
    public class RelItemSection : Base, IRelItemSection
    {
        [ForeignKey("Item")]
        public Guid ItemId { get; set; }
        [ForeignKey("Section")]
        public Guid SectionId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Section Section { get; set; }
    }
}
