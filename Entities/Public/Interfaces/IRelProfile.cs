using System;

namespace Entities.Public.Interfaces
{
    public interface IRelProfile
    {
        Guid ProfileId { get; set; }
        IProfile Profile { get; set; }
    }
}
