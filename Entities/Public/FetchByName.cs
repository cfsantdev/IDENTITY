using Entities.Public.Enums;
using Entities.Public.Interfaces;

namespace Entities.Public
{
    public class FetchByName : IFetchByName
    {
        public string Name { get; set; }

        public FetchByNamePattern FetchByNamePattern { get; set; }
    }
}
