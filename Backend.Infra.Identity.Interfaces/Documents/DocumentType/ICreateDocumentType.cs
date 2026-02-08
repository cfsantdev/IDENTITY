using Backend.Infra.Api.Crud.Interfaces;

namespace Backend.Infra.Identity.Interfaces.Documents.DocumentType
{
    public interface ICreateDocumentType : ICreate
    {
        int NumberOfDigits { get; set; }
    }
}
