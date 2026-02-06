using Entities.Identity.Interfaces;
using Entities.Public;

namespace Entities.Identity
{
    public class Document : BaseNamed, IDocument
    {
        public string Value { get; set; }
        public string Mask { get; set; }
    }
}
