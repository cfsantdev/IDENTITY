using Inventory.Models.Req.Interfaces;
using System;

namespace Inventory.Models.Req
{
    public class Create : ICreate
    {
        public Guid ItemId { get; set; }
        public Guid Assignor { get; set; }
        public Guid Assignee { get; set; }
        public decimal Amount { get; set; }
        public string TaxNumber { get; set; }
    }
}
