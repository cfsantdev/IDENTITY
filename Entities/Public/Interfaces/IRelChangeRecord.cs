using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Public.Interfaces
{
    public interface IRelChangeRecord
    {
        [ForeignKey("ChangeRecord")]
        Guid ChangeRecordId { get; set; }

        ChangeRecord ChangeRecord { get; set; }
    }
}
