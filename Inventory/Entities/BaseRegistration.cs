using Inventory.Models.Interfaces;

namespace Inventory.Models
{
    public class BaseRegistration : Base, IBaseRegistration
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
