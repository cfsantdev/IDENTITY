using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Identity.DTO.Interfaces.Documents.DocumentTypes
{
    public interface IDocumentTypeDTO
    {
        Guid Id { get; set; }
        int NumberOfDigits { get; set; }
        string? Name { get; set; }
        bool State { get; set; }
        DateTime? Insertion { get; set; }
        DateTime? Change { get; set; }
    }
}
