using Entities.Public.Interfaces;
using System;

namespace Entities.Public
{
    public class CreateRel : ICreateRel
    {
        public Guid CoverId { get; set; }
        public Guid RelatedId { get; set; }
    }
}
