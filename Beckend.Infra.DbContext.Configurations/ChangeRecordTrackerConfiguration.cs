using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Api.ChangeRecord.Configurations
{
    public class ChangeRecordTrackerConfiguration : IEntityTypeConfiguration<ChangeRecordTracker>
    {
        public void Configure(EntityTypeBuilder<ChangeRecordTracker> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(ChangeRecordTracker));

            entityTypeBuilder.Property(x => x.Insertion).HasDefaultValue(DateTime.Now);
            entityTypeBuilder.Property(x => x.Change).HasDefaultValue(null);
        }
    }
}
