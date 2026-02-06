using Backend.Infra.Api.Crud.Interfaces;

namespace Backend.Infra.Identity.Interfaces.Documents.DocumentType
{
    public interface IUpdateDocumentType : IUpdate
    {
        int NumberOfDigits { get; set; }
    }
}
