using Backend.Infra.Identity.Documents.DocumentType;
using Beckend.Infra.DbContext.Scaffold;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Identity.DbContext.Scaffold
{
    public class DocumentTypes : BaseContextScaffold<DocumentType>
    {
        public static void DocumentTypesBuilder(ModelBuilder builder, Guid owner, Guid publisher)
        {
            builder.Entity<DocumentType>().HasData(
                new DocumentType
                {
                    Id = Guid.NewGuid(),
                    State = true,
                    Name = "CPF",
                    NumberOfDigits = 11,
                    PublisherId = publisher,
                    OwnerId = owner,
                    Insertion = DateTime.Now
                },
                new DocumentType
                {
                    Id = Guid.NewGuid(),
                    State = true,
                    Name = "RG",
                    NumberOfDigits = 9,
                    PublisherId = publisher,
                    OwnerId = owner,
                    Insertion = DateTime.Now
                },
                new DocumentType
                {
                    Id = Guid.NewGuid(),
                    State = true,
                    Name = "CNPJ",
                    NumberOfDigits = 14,
                    PublisherId = publisher,
                    OwnerId = owner,
                    Insertion = DateTime.Now
                },
                new DocumentType
                {
                    Id = Guid.NewGuid(),
                    State = true,
                    Name = "CNH",
                    NumberOfDigits = 10,
                    PublisherId = publisher,
                    OwnerId = owner,
                    Insertion = DateTime.Now
                }
            );
        }
    }
}
