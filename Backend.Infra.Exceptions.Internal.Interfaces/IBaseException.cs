using System.Runtime.Serialization;

namespace Backend.Infra.Exceptions.Internal.Interfaces
{
    public interface IBaseException<TController, TException> : IDisposable where TException : Exception
    {
        string? ActionName { get; set; }

        TException? Exception { get; set; }

        public void Display();
    }
}
