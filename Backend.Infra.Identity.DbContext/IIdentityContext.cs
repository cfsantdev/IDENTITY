using Backend.Infra.Identity.Documents.Document;
using Backend.Infra.Identity.Documents.DocumentType;
using Beckend.Infra.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Identity.DbContext
{
    public interface IIdentityContext : IBaseDbContext
    {
        DbSet<Profile.Profile> Profile { get; set; }
        DbSet<Session.Session> Session { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<DocumentType> DocumentTypes { get; set; }
    }
}
