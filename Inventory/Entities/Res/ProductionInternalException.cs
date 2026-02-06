using Inventory.Models.Res.Interfaces;

namespace Inventory.Models.Res
{
    public class ProductionInternalException : InternalException, IProductionInternalException
    {
        public ProductionInternalException()
        {

        }

        public ProductionInternalException(string message, string detail)
        {
            Message = message;
            Detail = detail;
        }

        public string Detail { get; set; }
    }
}
