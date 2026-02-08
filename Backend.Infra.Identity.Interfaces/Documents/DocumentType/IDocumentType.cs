using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Identity.Interfaces.Documents.DocumentType
{
    public interface IDocumentType : IBase
    {
        int NumberOfDigits { get; set; }
    }
}
