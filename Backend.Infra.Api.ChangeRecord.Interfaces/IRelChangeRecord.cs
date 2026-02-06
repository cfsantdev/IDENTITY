using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Infra.Api.ChangeRecord.Interfaces
{
    public interface IRelChangeRecord<TChangeRecord> where TChangeRecord : IChangeRecord
    {
        [ForeignKey("ChangeRecord")]
        Guid ChangeRecordId { get; set; }

        TChangeRecord? ChangeRecord { get; set; }
    }
}
