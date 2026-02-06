using Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Catalog.Entities.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(Item));

            entityTypeBuilder.HasIndex(x => x.Name).IsUnique();
            entityTypeBuilder.Property(x => x.State).HasDefaultValue(true);
            entityTypeBuilder.Property(x => x.Insertion).HasDefaultValue(DateTime.Now);
            entityTypeBuilder.Property(x => x.Change).HasDefaultValue(DateTime.MinValue);
        }
    }
}
