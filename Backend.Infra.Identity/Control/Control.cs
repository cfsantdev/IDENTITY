using Backend.Infra.Base;
using Backend.Infra.Base.Interfaces;
using Backend.Infra.Identity.Branch;
using Backend.Infra.Identity.Documents.DocumentType;
using NJsonSchema.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Infra.Identity.Control
{
    public class Control : BaseStateful, IBaseStateful
    {
        [ForeignKey("ControlType")]
        public Guid ControlTypeId { get; set; }

        [ForeignKey("Branch")]
        public Guid BranchId { get; set; }

        [Range(1,12)]
        [NotNull]
        public int Month { get; set; }
        public int Year { get; set; }

        public decimal Transported { get; set; }
        public decimal LitersSpent { get; set; }
        public decimal Cost { get; set; }
        public decimal CostPerCubicMeter { get; set; }
        public decimal CostPerLiter { get; set; }

        public virtual ControlType? ControlType { get; set; }
        public virtual Branch.Branch? Branch { get; set; }
    }
}
