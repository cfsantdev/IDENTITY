using Backend.Infra.Exceptions.Interfaces;

namespace Backend.Infra.Exceptions
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
