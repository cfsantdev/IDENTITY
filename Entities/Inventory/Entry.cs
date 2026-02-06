using Entities.Inventory.Interface;
using Entities.Public;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Inventory
{
    public class Entry : BaseNamedStateful, IEntry
    {
        [ForeignKey("Item")]
        public Guid ItemId { get; set; }
        [ForeignKey("Assignor")]
        public Guid AssignorId { get; set; }
        [ForeignKey("Assignee")]
        public Guid AssigneeId { get; set; }
        public decimal Amount { get; set; }
        public string SKU { get; set; }

        public Profile Assignor { get; set; }
        public Profile Assignee { get; set; }
    }
}
