using Inventory.Models.Res.Interfaces;

namespace Inventory.Models.Res
{
    public class InternalException : IInternalException
    {
        public InternalException()
        {

        }

        public InternalException(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
