using Backend.Infra.Api.ChangeRecord.DTO.Interfaces;
using Backend.Infra.Api.ChangeRecord.Interfaces;

namespace Backend.Infra.Api.ChangeRecord.DTO
{
    public class ChangeRecordTrackerDTO : ChangeRecordTracker, IChangeRecordTrackerDTO<ChangeRecordDTO>
    {
        ChangeRecordDTO IRelChangeRecord<ChangeRecordDTO>.ChangeRecord { get; set; }
    }
}
