using Entities.Public.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Public
{
    public class ChangeRecordTracker : BaseNamed, IChangeRecordTracker
    {
        [ForeignKey("ChangeRecord")]
        public Guid ChangeRecordId { get; set; }
        public Guid RecordIdentifier { get; set; }

        public virtual ChangeRecord ChangeRecord { get; set; }
    }
}
