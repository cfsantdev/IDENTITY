using Backend.Infra.Api.ChangeRecord.Interfaces;
using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Api.ChangeRecord.DTO.Interfaces
{
    public interface IChangeRecordTrackerDTO<TChangeRecord> : IChangeRecordTracker<TChangeRecord>, IRelChangeRecord<TChangeRecord>, IBaseNamed where TChangeRecord : IChangeRecordDTO
    {
    }
}
