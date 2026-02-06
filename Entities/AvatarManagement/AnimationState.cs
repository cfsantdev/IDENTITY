using Entities.Public.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.AvatarManagement
{
    public class AnimationState : IBaseNamed
    {
        public Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public DateTime Insertion { get; set; }
        public DateTime Change { get; set; }

        [ForeignKey("Animation")]
        public Guid AnimationId { get; set; }
        public virtual Animation Animation { get; set; }
        
        public int Index { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnimationStateItem> AnimationStateItemCollection { get; set; }
    }
}
