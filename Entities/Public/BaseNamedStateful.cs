using Entities.Public.Interfaces;

namespace Entities.Public
{
    public class BaseNamedStateful : Base, IBaseNamedStateful
    {
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
