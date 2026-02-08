using Backend.Infra.Base.Interfaces;
using System.Text.Json.Serialization;

namespace Backend.Infra.Base
{
    public class BaseNamedStateful : Base, IBaseNamedStateful
    {
        public string? Name { get; set; }
        public bool State { get; set; }
    }
}
