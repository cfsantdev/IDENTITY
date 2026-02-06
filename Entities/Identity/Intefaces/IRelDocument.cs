using System;

namespace Entities.Identity.Interfaces
{
    public interface IRelDocument
    {
        Guid DocumentId { get; set; }
        IDocument Document { get; set; }
    }
}
