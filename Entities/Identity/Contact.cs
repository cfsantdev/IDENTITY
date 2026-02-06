using Entities.Identity.Enums;
using Entities.Identity.Interfaces;
using Entities.Public;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Identity
{
    public class Contact : BaseNamedStateful, IContact
    {
        public string Value { get; set; }
        public string Mask { get; set; }
        public ContactType ContactType { get; set; }
        [NotMapped]
        public int ContactTypeId {
            get
            {
                return (int)ContactType;
            }
        }
    }
}
