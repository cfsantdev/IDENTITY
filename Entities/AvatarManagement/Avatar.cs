using Entities.Public.Interfaces;
using System;
using System.Collections.Generic;

namespace Entities.AvatarManagement
{
    public class Avatar : IBase
    {
        public Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public DateTime Insertion { get; set; }
        public DateTime Change { get; set; }

        public string Src { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public int V { get; set; }

        public virtual ICollection<Animation> AnimationCollection { get; set; }
    }
}
