using Entities.Public.Interfaces;

namespace Entities.Public
{
    public class BaseStateful : Base, IBase, IBaseStateful
    {
        public bool State { get; set; }
    }
}
