using Entities.Public.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.AvatarManagement
{
    public class Animation : IBase
    {
        public Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public DateTime Insertion { get; set; }
        public DateTime Change { get; set; }

        [ForeignKey("Avatar")]
        public Guid AvatarId { get; set; }
        public virtual Avatar Avatar { get; set; }

        public string Src { get; set; }
        public int IdleStateAnimationTimer { get; set; }

        public virtual ICollection<AnimationState> AnimationStateCollection { get; set; }
    }
}
