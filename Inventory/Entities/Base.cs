using Inventory.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Base : IBase
    {
        [Key]
        public Guid? Id { get; set; }
        public DateTime Insertion { get; set; }
        public DateTime Change { get; set; }
    }
}
