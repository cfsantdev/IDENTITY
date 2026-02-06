using Backend.Infra.Base;
using Backend.Infra.Identity.Interfaces.Documents.DocumentType;

namespace Backend.Infra.Identity.Documents.DocumentType
{
    public class DocumentType : BaseNamedStateful, IDocumentType
    {
        public int NumberOfDigits { get; set; }
    }
}
