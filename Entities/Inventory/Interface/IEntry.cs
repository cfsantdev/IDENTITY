using Entities.Public;
using Entities.Public.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Inventory.Interface
{
    public interface IEntry : IBaseNamedStateful
    {
        Guid ItemId { get; set; }
        Guid AssignorId { get; set; }
        Guid AssigneeId { get; set; }
        decimal Amount { get; set; }
        string SKU { get; set; }

        Profile Assignor { get; set; }
        Profile Assignee { get; set; }
    }
}
