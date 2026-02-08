using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Api.ChangeRecord.Interfaces
{
    public interface IChangeRecord : IBaseNamedStateful
    {
        Guid RecordIdentifier { get; set; }
        string? SerializedPrevious { get; set; }
        string? SerializedCurrent { get; set; }
    }
}
