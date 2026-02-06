using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Public.Interfaces
{
    public interface IBase
    {
        [Key]
        Guid? Id { get; set; }
        Guid? OwnerId { get; set; }
        Guid? PublisherId { get; set; }
        DateTime Insertion { get; set; }
        DateTime Change { get; set; }
    }
}
