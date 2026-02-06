using System;

namespace Entities.Public.Interfaces
{
    public interface ICreateRel
    {
        Guid CoverId { get; set; }
        Guid RelatedId { get; set; }
    }
}
