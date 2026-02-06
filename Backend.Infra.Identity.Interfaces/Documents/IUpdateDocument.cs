using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Identity.Interfaces.Documents
{
    public interface IUpdateDocument : IUpdate
    {
        Guid DocumentTypeId { get; set; }
        string Value { get; set; }
    }
}
