using Backend.Infra.Api.Crud;
using Backend.Infra.Identity.Interfaces.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infra.Identity.Documents.Document
{
    public class UpdateDocument : Update, IUpdateDocument
    {
        public Guid DocumentTypeId { get; set; }
        public string Value { get; set; }
    }
}
