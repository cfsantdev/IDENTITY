using Entities.Public.Interfaces;

namespace Entities.Identity.Interfaces
{
    public interface IDocument : IBaseNamed
    {
        string Value { get; set; }
        string Mask { get; set; }
    }
}
