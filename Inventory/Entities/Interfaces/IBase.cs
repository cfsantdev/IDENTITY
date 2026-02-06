using System;

namespace Inventory.Models.Interfaces
{
    public interface IBase
    {
        Guid? Id { get; set; }
        DateTime Insertion { get; set; }
        DateTime Change { get; set; }
    }
}
