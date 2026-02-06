using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Base
{
    public class BaseStateful : Base, IBase, IBaseStateful
    {
        public bool State { get; set; }
    }
}
