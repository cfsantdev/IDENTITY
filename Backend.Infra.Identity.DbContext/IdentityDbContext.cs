using Backend.Infra.Identity.DbContext.Configurations;
using Backend.Infra.Identity.DbContext.Scaffold;
using Backend.Infra.Identity.DbContext.Settings;
using Backend.Infra.Identity.Documents.Document;
using Backend.Infra.Identity.Documents.DocumentType;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Identity.DbContext
{
    public class IdentityDbContext : Beckend.Infra.DbContext.BaseDbContext<IdentityDbContext>,
        IIdentityContext
    {
        public readonly PublishersSettings PUBLISHER_SETTINGS = new PublishersSettings();

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {

        }

        public DbSet<Profile.Profile> Profile { get; set; }
        public DbSet<Session.Session> Session { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());

            Profiles.ProfilesBuilder(modelBuilder,
                Guid.Parse(PUBLISHER_SETTINGS.RecordChangePublisher),
                Guid.Parse(PUBLISHER_SETTINGS.RecordChangeTrackerPublisher),
                Guid.Parse(PUBLISHER_SETTINGS.ProfilePublisher),
                Guid.Parse(PUBLISHER_SETTINGS.SessionPublisher),
                Guid.Parse(PUBLISHER_SETTINGS.DocumentPublisher),
                Guid.Parse(PUBLISHER_SETTINGS.DocumentTypePublisher),
                out Guid admin_uuid);

            Scaffold.DocumentTypes.DocumentTypesBuilder(modelBuilder, admin_uuid, Guid.Parse(PUBLISHER_SETTINGS.DocumentTypePublisher));
        }
    }
}