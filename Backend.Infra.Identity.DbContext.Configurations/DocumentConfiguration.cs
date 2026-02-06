using Backend.Infra.Identity.Documents.Document;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Identity.DbContext.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(nameof(Document));

            entityTypeBuilder.Navigation(x => x.DocumentType).UsePropertyAccessMode(PropertyAccessMode.Property);
            entityTypeBuilder.HasIndex(x => x.Value).IsUnique();
            entityTypeBuilder.Property(x => x.Value).IsRequired();
            entityTypeBuilder.Property(x => x.Insertion).HasDefaultValue(DateTime.Now);
            entityTypeBuilder.Property(x => x.Change).HasDefaultValue(DateTime.MinValue);
            entityTypeBuilder.Property(x => x.OwnerId).HasDefaultValue(Guid.Empty);
            entityTypeBuilder.Property(x => x.PublisherId).HasDefaultValue(Guid.Empty);
        }
    }
}
