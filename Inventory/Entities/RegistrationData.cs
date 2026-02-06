using Inventory.Models.Interfaces;
using System;

namespace Inventory.Models
{
    public class RegistrationData : Base, IRegistrationData
    {
        public Guid ItemId { get; set; }
        public Guid Assignor { get; set; }
        public Guid Assignee { get; set; }
        public decimal Amount { get; set; }
        public string TaxNumber { get; set; }
    }
}