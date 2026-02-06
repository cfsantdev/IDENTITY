using Catalog.Entities.Configurations;
using Entities.Catalog;
using Entities.Public.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Catalog
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {

        }

        public DbSet<Item> Itens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RelItemCategory> RelItemCategory { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<RelItemSection> RelItemSection { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");

            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new RelItemCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new RelItemSectionConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var registry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList())
            {
                if (registry.Entity is not IBase)
                {
                    continue;
                }

                ((IBase)registry.Entity).Change = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}
