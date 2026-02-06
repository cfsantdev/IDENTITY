using Backend.Infra.Identity.DTO.Interfaces.Documents;

namespace Backend.Infra.Identity.DTO.Documents
{
    public class DocumentDTO : IDocumentDTO
    {
        public Guid Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public DateTime? Insertion { get; set; }
        public DateTime? Change { get; set; }
        public string Value { get; set; }
    }
}
