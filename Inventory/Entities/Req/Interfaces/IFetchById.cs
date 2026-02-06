using System;

namespace Inventory.Models.Req.Interfaces
{
    public interface IFetchById
    {
        Guid Id { get; set; }
    }
}
