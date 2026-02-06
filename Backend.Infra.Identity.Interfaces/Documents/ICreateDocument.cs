namespace Backend.Infra.Identity.Interfaces.Documents
{
    public interface ICreateDocument
    {
        Guid? OwnerId { get; set; }
        Guid DocumentTypeId { get; set; }
        string? Value { get; set; }
    }
}
