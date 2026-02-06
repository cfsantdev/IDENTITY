using Entities.Catalog.Interfaces;
using Entities.Public;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Catalog
{
    public class RelItemCategory : Base, IRelItemCategory
    {
        [ForeignKey("Item")]
        public Guid ItemId { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Category Category { get; set; }
    }
}
