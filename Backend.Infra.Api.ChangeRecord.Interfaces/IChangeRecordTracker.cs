using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Api.ChangeRecord.Interfaces
{
    public interface IChangeRecordTracker<TChangeRecord> : IRelChangeRecord<TChangeRecord>, IBaseNamed where TChangeRecord : IChangeRecord
    {
        Guid RecordIdentifier { get; set; }
    }
}
