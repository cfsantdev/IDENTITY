namespace Backend.Infra.Exceptions.Interfaces
{
    public interface IProductionInternalException : IInternalException
    {
        string Detail { get; set; }
    }
}
