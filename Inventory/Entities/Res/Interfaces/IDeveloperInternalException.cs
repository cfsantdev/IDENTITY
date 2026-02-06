using System;

namespace Inventory.Models.Res.Interfaces
{
    public interface IDeveloperInternalException : IInternalException
    {
        Exception? InnerException { get; set; }
        string StackTrace { get; set; }
    }
}
