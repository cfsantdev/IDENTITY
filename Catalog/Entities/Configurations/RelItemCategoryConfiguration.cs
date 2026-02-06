using Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Catalog.Entities.Configurations
{
    public class RelItemCategoryConfiguration : IEntityTypeConfiguration<RelItemCategory>
    {
        public void Configure(EntityTypeBuilder<RelItemCategory> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(RelItemCategory));

            entityTypeBuilder.HasIndex(x => x.ItemId).IsUnique();
            entityTypeBuilder.Property(x => x.Insertion).HasDefaultValue(DateTime.Now);
            entityTypeBuilder.Property(x => x.Change).HasDefaultValue(DateTime.MinValue);
        }
    }
}
