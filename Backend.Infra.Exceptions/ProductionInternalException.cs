using Backend.Infra.Exceptions.Interfaces;

namespace Backend.Infra.Exceptions
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
