using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Base
{
    public class BaseNamed : Base, IBase, IBaseNamed
    {
        public string? Name { get; set; }
    }
}
