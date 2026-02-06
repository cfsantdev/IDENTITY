using Entities.Public.Interfaces;
using System;

namespace Entities.Public
{
    public class UpdateRel : IUpdateRel
    {
        public Guid Id { get; set; }
        public Guid CoverId { get; set; }
        public Guid RelatedId { get; set; }
    }
}
