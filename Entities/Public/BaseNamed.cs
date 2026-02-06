using Entities.Public.Interfaces;

namespace Entities.Public
{
    public class BaseNamed : Base, IBase, IBaseNamed
    {
        public string Name { get; set; }
    }
}
