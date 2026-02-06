using System;

namespace Entities.Public.Interfaces
{
    public interface IDeveloperInternalException : IInternalException
    {
        Exception? InnerException { get; set; }
        string StackTrace { get; set; }
    }
}
