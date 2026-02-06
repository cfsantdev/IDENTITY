using System;

namespace Entities.Public.Interfaces
{
    public interface IShell<T> where T : IBase
    {
        Guid Token { get; set; }
        T Content { get; set; }
    }
}
