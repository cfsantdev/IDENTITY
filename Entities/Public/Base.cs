using Entities.Public.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Public
{
    public class Base : IBase
    {
        [Key]
        public Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public DateTime Insertion { get; set; }
        public DateTime Change { get; set; }
    }
}
