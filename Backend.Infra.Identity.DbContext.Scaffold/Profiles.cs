using Backend.Infra.Enumerators;
using Base.Infra.Cryptography;
using Beckend.Infra.DbContext.Scaffold;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Identity.DbContext.Scaffold
{
    public class Profiles : BaseContextScaffold<Profile.Profile>
    {
        public static void ProfilesBuilder(ModelBuilder builder, 
            Guid publisher_rc,
            Guid publisher_rct, 
            Guid publisher_profile, 
            Guid publisher_session,
            Guid publisher_doc,
            Guid publisher_doc_type,
            out Guid admin_uuid)
        {
            admin_uuid = Guid.NewGuid();

            //
            // Build ADMIN profile
            //

            builder.Entity<Profile.Profile>().HasData(
                new Profile.Profile
                {
                    Id = admin_uuid,
                    Name = "admin",
                    Password = Crypto.EncodeToBase64("123@alpha"),
                    Email = "cfs.plus.s8@gmail.com",
                    Role = new string[1] { Roles.ADMIN }
                }
            );

            //
            // Build profile publisher
            //

            Guid pProfileUuid = Guid.NewGuid();
            builder.Entity<Profile.Profile>().HasData(
                new Profile.Profile
                {
                    Id = publisher_profile,
                    OwnerId = admin_uuid,
                    PublisherId = admin_uuid,
                    Name = "publisher.profile",
                    Password = Crypto.EncodeToBase64(pProfileUuid.ToString()),
                    Email = "publisher.profile@gmail.com",
                    Role = new string[1] { Roles.PUBLISHER }
                }
            );

            //
            // Build other publishers
            //

            Guid pRecordChangeUuid = Guid.NewGuid();
            Guid pRecordChangeTrackerUuid = Guid.NewGuid();
            Guid pSessionUuid = Guid.NewGuid();
            Guid pDocumentUuid = Guid.NewGuid();
            Guid pDocumentTypeUuid = Guid.NewGuid();
            builder.Entity<Profile.Profile>().HasData(
                new Profile.Profile
                {
                    Id = publisher_rc,
                    OwnerId = admin_uuid,
                    PublisherId = publisher_profile,
                    Name = "publisher.rc",
                    Password = Crypto.EncodeToBase64(pRecordChangeUuid.ToString()),
                    Email = "publisher.rc@gmail.com",
                    Role = new string[1] { Roles.PUBLISHER }
                },
                new Profile.Profile
                {
                    Id = publisher_rct,
                    OwnerId = admin_uuid,
                    PublisherId = publisher_profile,
                    Name = "publisher.rct",
                    Password = Crypto.EncodeToBase64(pRecordChangeTrackerUuid.ToString()),
                    Email = "publisher.rct@gmail.com",
                    Role = new string[1] { Roles.PUBLISHER }
                },
                new Profile.Profile
                {
                    Id = publisher_session,
                    OwnerId = admin_uuid,
                    PublisherId = publisher_profile,
                    Name = "publisher.session",
                    Password = Crypto.EncodeToBase64(pSessionUuid.ToString()),
                    Email = "publisher.session@gmail.com",
                    Role = new string[1] { Roles.PUBLISHER }
                },
                new Profile.Profile
                {
                    Id = publisher_doc,
                    OwnerId = admin_uuid,
                    PublisherId = publisher_profile,
                    Name = "publisher.doc",
                    Password = Crypto.EncodeToBase64(pDocumentUuid.ToString()),
                    Email = "publisher.doc@gmail.com",
                    Role = new string[1] { Roles.PUBLISHER }
                },
                new Profile.Profile
                {
                    Id = publisher_doc_type,
                    OwnerId = admin_uuid,
                    PublisherId = publisher_profile,
                    Name = "publisher.doc.type",
                    Password = Crypto.EncodeToBase64(pDocumentTypeUuid.ToString()),
                    Email = "publisher.doc.type@gmail.com",
                    Role = new string[1] { Roles.PUBLISHER }
                }
            );
        }
    }
}
