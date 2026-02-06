using Backend.Infra.Base.Interfaces;
using Backend.Infra.Identity.Interfaces.Documents.DocumentType;

namespace Backend.Infra.Identity.Interfaces.Documents
{
    public interface IDocument : IBase
    {
        Guid DocumentTypeId { get; set; }
        string Value { get; set; }
    }
}
