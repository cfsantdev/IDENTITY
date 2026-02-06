using System;

namespace Entities.Public.Interfaces
{
    public interface IUpdate
    {
        Guid? Id { get; set; }
        Guid? PublisherId { get; set; }
        string Name { get; set; }
        bool State { get; set; }
    }
}
