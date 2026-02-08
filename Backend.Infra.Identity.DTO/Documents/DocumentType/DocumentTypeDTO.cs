using Backend.Infra.Identity.DTO.Interfaces.Documents.DocumentTypes;

namespace Backend.Infra.Identity.DTO.Documents.DocumentType
{
    public class DocumentTypeDTO : IDocumentTypeDTO
    {
        public Guid Id { get; set; }
        public int NumberOfDigits { get; set; }
        public string? Name { get; set; }
        public bool State { get; set; }
        public DateTime? Insertion { get; set; }
        public DateTime? Change { get; set; }
    }
}
