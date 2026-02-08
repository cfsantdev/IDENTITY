namespace Backend.Infra.Identity.DTO.Interfaces.Documents
{
    public interface IDocumentDTO
    {
        Guid Id { get; set; }
        Guid? OwnerId { get; set; }
        Guid? PublisherId { get; set; }
        Guid DocumentTypeId { get; set; }
        DateTime? Insertion { get; set; }
        DateTime? Change { get; set; }
        string Value { get; set; }
    }
}
