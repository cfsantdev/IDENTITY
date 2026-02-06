namespace Entities.Public.Interfaces
{
    interface IProductionInternalException : IInternalException
    {
        string Detail { get; set; }
    }
}
