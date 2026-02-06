using System;

namespace Entities.Public.Interfaces
{
    public interface IUpdateRel
    {
        Guid Id { get; set; }
        Guid CoverId { get; set; }
        Guid RelatedId { get; set; }
    }
}
