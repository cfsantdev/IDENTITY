using Backend.Infra.Api.Crud;
using Backend.Infra.Identity.Interfaces.Documents.DocumentType;

namespace Backend.Infra.Identity.Documents.DocumentType
{
    public class UpdateDocumentType : Update, IUpdateDocumentType
    {
        public int NumberOfDigits { get; set; }
    }
}
