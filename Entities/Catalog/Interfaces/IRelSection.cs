using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Catalog.Interfaces
{
    public interface IRelSection
    {
        [ForeignKey("Section")]
        Guid SectionId { get; set; }
        Section Section { get; set; }
    }
}
