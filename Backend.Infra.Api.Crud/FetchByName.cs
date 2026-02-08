using Backend.Infra.Enumerators;
using Backend.Infra.Api.Crud.Interfaces;

namespace Backend.Infra.Api.Crud
{
    public class FetchByName : IFetchByName
    {
        public string Name { get; set; }

        public FetchByNamePattern FetchByNamePattern { get; set; }
    }
}
