using Entities.AvatarManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AvatarManagement.Entities.Configurations
{
    public class AvatarConfiguration : IEntityTypeConfiguration<Avatar>
    {
        public void Configure(EntityTypeBuilder<Avatar> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(Avatar));

            entityTypeBuilder.Property(x => x.Insertion).HasDefaultValue(DateTime.Now);
            entityTypeBuilder.Property(x => x.Change).HasDefaultValue(DateTime.MinValue);
            entityTypeBuilder.Property(x => x.OwnerId).HasDefaultValue(Guid.Empty);
            entityTypeBuilder.Property(x => x.PublisherId).HasDefaultValue(Guid.Empty);
        }
    }
}
