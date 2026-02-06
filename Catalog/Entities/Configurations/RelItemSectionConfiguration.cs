using Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Catalog.Entities.Configurations
{
    public class RelItemSectionConfiguration : IEntityTypeConfiguration<RelItemSection>
    {
        public void Configure(EntityTypeBuilder<RelItemSection> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(RelItemSection));

            entityTypeBuilder.HasIndex(x => x.ItemId).IsUnique();
            entityTypeBuilder.Property(x => x.Insertion).HasDefaultValue(DateTime.Now);
            entityTypeBuilder.Property(x => x.Change).HasDefaultValue(DateTime.MinValue);
        }
    }
}
