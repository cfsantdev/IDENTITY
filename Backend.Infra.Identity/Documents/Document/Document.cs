using Backend.Infra.Identity.Interfaces.Documents;
using Backend.Infra.Identity.Interfaces.Documents.DocumentType;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Infra.Identity.Documents.Document
{
    public class Document : Base.Base, IDocument
    {
        [ForeignKey("DocumentType")]
        public Guid DocumentTypeId { get; set; }
        public string Value { get; set; }

        public virtual DocumentType.DocumentType DocumentType { get; set; }
    }
}
