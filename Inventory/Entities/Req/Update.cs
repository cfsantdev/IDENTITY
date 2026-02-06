using Inventory.Models.Req.Interfaces;
using System;

namespace Inventory.Models.Req
{
    public class Update : IUpdate
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        // Cedente: aquele que transfere o crédito
        public Guid Assignor { get; set; }
        // Cessionário: aquele que recebeu o crédito
        public Guid Assignee { get; set; }
        public decimal Amount { get; set; }
        public string TaxNumber { get; set; }
    }
}
