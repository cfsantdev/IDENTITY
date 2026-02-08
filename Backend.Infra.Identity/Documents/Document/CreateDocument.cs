using Backend.Infra.Identity.Interfaces.Documents;

namespace Backend.Infra.Identity.Documents.Document
{
    public class CreateDocument : ICreateDocument
    {
        public Guid? OwnerId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public string? Value { get; set; }
    }
}
