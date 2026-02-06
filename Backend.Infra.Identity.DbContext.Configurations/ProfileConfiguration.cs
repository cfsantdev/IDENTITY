using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Identity.DbContext.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile.Profile>
    {
        public void Configure(EntityTypeBuilder<Profile.Profile> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(Profile));

            entityTypeBuilder.HasIndex(x => x.Name).IsUnique();
            entityTypeBuilder.HasIndex(x => x.Email).IsUnique();
            entityTypeBuilder.Property(x => x.Email).IsRequired();
            entityTypeBuilder.Property(x => x.State).HasDefaultValue(true);
            entityTypeBuilder.Property(x => x.Insertion).HasDefaultValue(DateTime.Now);
            entityTypeBuilder.Property(x => x.Change).HasDefaultValue(DateTime.MinValue);
            entityTypeBuilder.Property(x => x.OwnerId).HasDefaultValue(Guid.Empty);
            entityTypeBuilder.Property(x => x.PublisherId).HasDefaultValue(Guid.Empty);
        }
    }
}
