using Backend.Infra.Exceptions.Interfaces;
using System;

namespace Backend.Infra.Exceptions
{
    public class DeveloperInternalException : InternalException, IDeveloperInternalException
    {
        public DeveloperInternalException()
        {

        }

        public DeveloperInternalException(string message, Exception? exception, string stackTrace)
        {
            Message = message;
            InnerException = exception;
            StackTrace = stackTrace;
        }

        public Exception InnerException { get; set; }
        public string StackTrace { get; set; }
    }
}
