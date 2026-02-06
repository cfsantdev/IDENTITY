using System;

namespace Inventory.Models.Req.Interfaces
{
    public interface IUpdate
    {
        Guid Id { get; set; }
        Guid ItemId { get; set; }
        // Cedente: aquele que transfere o crédito
        Guid Assignor { get; set; }
        // Cessionário: aquele que recebeu o crédito
        Guid Assignee { get; set; }
        decimal Amount { get; set; }
        string TaxNumber { get; set; }
    }
}
