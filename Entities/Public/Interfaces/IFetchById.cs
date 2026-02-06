using System;

namespace Entities.Public.Interfaces
{
    public interface IFetchById
    {
        Guid Id { get; set; }
        Guid PublisherId { get; set; }
    }
}
