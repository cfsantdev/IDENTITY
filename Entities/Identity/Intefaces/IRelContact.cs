using System;

namespace Entities.Identity.Interfaces
{
    public interface IRelContact
    {
        Guid ContactId { get; set; }
        IContact Contact { get; set; }
    }
}
