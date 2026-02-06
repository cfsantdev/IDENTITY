using Entities.Public.Interfaces;
using System;

namespace Entities.Public
{
    public class Shell<T> where T : IBase
    {
        public Guid Token { get; set; }
        public T Content { get; set; }
    }
}
