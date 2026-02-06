using Entities.Identity.Enums;
using Entities.Public.Interfaces;

namespace Entities.Identity.Interfaces
{
    public interface IContact : IBaseNamedStateful
    {
        string Value { get; set; }
        string Mask { get; set; }
        
        ContactType ContactType { get; set; }
        int ContactTypeId { get; }
    }
}
