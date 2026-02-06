using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Catalog.Interfaces
{
    public interface IRelCategory
    {
        [ForeignKey("Category")]
        Guid CategoryId { get; set; }
        Category Category { get; set; }
    }
}
