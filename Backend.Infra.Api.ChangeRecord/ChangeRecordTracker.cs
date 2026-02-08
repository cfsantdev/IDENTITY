using Backend.Infra.Base;
using Backend.Infra.Api.ChangeRecord.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Infra.Api.ChangeRecord
{
    public class ChangeRecordTracker : BaseNamed, IChangeRecordTracker<ChangeRecord>
    {
        [ForeignKey("ChangeRecord")]
        public Guid ChangeRecordId { get; set; }
        public Guid RecordIdentifier { get; set; }
        public string? SerializedPreviousHash { get; set; }
        public string? SerializedCurrentHash { get; set; }

        public virtual ChangeRecord? ChangeRecord { get; set; }
    }
}
