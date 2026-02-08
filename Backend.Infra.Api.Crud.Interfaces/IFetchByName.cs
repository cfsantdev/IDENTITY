using Backend.Infra.Enumerators;

namespace Backend.Infra.Api.Crud.Interfaces
{
    public interface IFetchByName
    {
        string Name { get; set; }

        FetchByNamePattern FetchByNamePattern { get; set; }
    }
}
