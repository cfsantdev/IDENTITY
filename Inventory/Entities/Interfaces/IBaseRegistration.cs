namespace Inventory.Models.Interfaces
{
    public interface IBaseRegistration : IBase
    {
        string Name { get; set; }
        bool Status { get; set; }
    }
}
