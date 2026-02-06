using Entities.Public.Interfaces;
using System;

namespace Entities.Public
{
    public class Update : IUpdate
    {
        public Guid? Id { get; set; }
        public Guid? PublisherId { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
