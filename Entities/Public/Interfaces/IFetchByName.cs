using Entities.Public.Enums;

namespace Entities.Public.Interfaces
{
    public interface IFetchByName
    {
        string Name { get; set; }

        FetchByNamePattern FetchByNamePattern { get; set; }
    }
}
