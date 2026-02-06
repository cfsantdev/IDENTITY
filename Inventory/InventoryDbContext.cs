using Inventory.Models;
using Inventory.Models.Configurations;
using Inventory.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {

        }

        public DbSet<RegistrationData> RegistrationData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");

            modelBuilder.ApplyConfiguration(new RegistrationDataConfiguration());
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
