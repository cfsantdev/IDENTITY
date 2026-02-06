using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models.Configurations
{
    public class RegistrationDataConfiguration : IEntityTypeConfiguration<RegistrationData>
    {
        public void Configure(EntityTypeBuilder<RegistrationData> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(RegistrationData));

            entityTypeBuilder.Property(x => x.Insertion).HasDefaultValue(DateTime.Now);
            entityTypeBuilder.Property(x => x.Change).HasDefaultValue(DateTime.MinValue);
        }
    }
}
