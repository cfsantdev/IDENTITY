using Backend.Infra.Api.Crud;
using Backend.Infra.Identity.Interfaces.Documents.DocumentType;

namespace Backend.Infra.Identity.Documents.DocumentType
{
    public class CreateDocumentType : Create, ICreateDocumentType
    {
        public Guid OwnerId { get; set; }
        public int NumberOfDigits { get; set; }
    }
}
