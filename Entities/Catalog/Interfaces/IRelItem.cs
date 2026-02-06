using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Catalog.Interfaces
{
    public interface IRelItem
    {
        [ForeignKey("Item")]
        Guid ItemId { get; set; }

        Item Item { get; set; }
    }
}
