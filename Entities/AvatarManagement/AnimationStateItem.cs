using Entities.Public.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.AvatarManagement
{
    public class AnimationStateItem : IBase
    {
        public Guid? Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? PublisherId { get; set; }
        public DateTime Insertion { get; set; }
        public DateTime Change { get; set; }

        [ForeignKey("AnimationState")]
        public Guid AnimationStateId { get; set; }
        public virtual AnimationState AnimationState { get; set; }

        public int Index { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
