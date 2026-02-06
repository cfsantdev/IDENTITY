using Backend.Infra.Base;
using Backend.Infra.Base.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Infra.Identity.Branch
{
    public class Branch : BaseNamedStateful, IBaseNamedStateful
    {
        [ForeignKey("Responsible")]
        public Guid ResponsibleId { get; set; }

        public Profile.Profile Responsible { get; set; }
    }
}
