    using Backend.Infra.Api.ChangeRecord;
using Backend.Infra.Api.ChangeRecord.Configurations;
using Backend.Infra.Base.Interfaces;
using Backend.Infra.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Beckend.Infra.DbContext
{
    public class BaseDbContext<T> : Microsoft.EntityFrameworkCore.DbContext,
        IBaseDbContext
        where T : Microsoft.EntityFrameworkCore.DbContext
    {
        private const string BACKEND_INFRA_API_CHANGERECORD_CHANGERECORD = "Backend.Infra.Api.ChangeRecord.ChangeRecord";
        private const string BACKEND_INFRA_API_CHANGERECORD_CHANGERECORDTRACKER = "Backend.Infra.Api.ChangeRecord.ChangeRecordTracker";

        private object? _previous { get; set; }

        public BaseDbContext(DbContextOptions<T> options)
            : base(options)
        {
        }

        public DbSet<ChangeRecord>? ChangeRecord { get; set; }
        public DbSet<ChangeRecordTracker>? ChangeRecordTracker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");

            modelBuilder.ApplyConfiguration(new ChangeRecordConfiguration());
            modelBuilder.ApplyConfiguration(new ChangeRecordTrackerConfiguration());
        }

        /// <summary>
        /// Get all data flow entries
        /// </summary>
        private List<EntityEntry> _entries
        {
            get
            {
                return ChangeTracker.Entries()?.ToList();
            }
        }

        /// <summary>
        /// Get modified data flow entries
        /// </summary>
        private List<EntityEntry> _modified
        {
            get
            {
                return ChangeTracker.Entries()?.Where(e => e.State == EntityState.Modified)?.ToList();
            }
        }

        /// <summary>
        /// Get added data flow entries
        /// </summary>
        private List<EntityEntry> _added
        {
            get
            {
                return ChangeTracker.Entries()?.Where(e => e.State == EntityState.Added)?.ToList();
            }
        }

        /// <summary>
        /// Custom 'SaveChanges' implementation by cfsant
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                if (!this.SaveChangesValidate())
                {
                    return base.SaveChanges();
                }

                this.ECRT();

                return base.SaveChanges();
            }
            finally
            {
                this._previous = null;
            }
        }

        public virtual void ECRT()
        {
            this.Added();
            this.Modified();
        }

        /// <summary>
        /// Custom validation method for 'SaveChanges'
        /// </summary>
        /// <returns></returns>
        private bool SaveChangesValidate()
        {
            var entries = ChangeTracker.Entries()?.ToList();
            if (entries == null || entries == default || entries.Count() < 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Data ENTRY flow
        /// </summary>
        /// <returns></returns>
        private void Added()
        {
            var added = this._added;
            if (!this.AddedValidate(added))
            {
                return;
            }

            added.ForEach(entry => AddEntry(entry));
        }

        private void AddEntry(EntityEntry entry)
        {
            if (!this.AddEntryValidate(entry))
            {
                return;
            }

            if (this.AddChangeRecord(entry))
            {
                return;
            }

            ((IBase)entry.Entity).Insertion = DateTime.Now;
        }

        private bool AddEntryValidate(EntityEntry entry)
        {
            if (entry == null || entry == default)
            {
                return false;
            }

            if (entry.Entity == null || entry.Entity == default)
            {
                return false;
            }

            if (!typeof(IBase).IsAssignableFrom(entry.Entity.GetType()))
            {
                return false;
            }

            return true;
        }

        private bool AddedValidate(List<EntityEntry> added)
        {
            if (added == null || added == default || added.Count < 1)
            {
                return false;
            }

            return true;
        }

        private bool AddChangeRecord(EntityEntry entry)
        {
            if (!this.AddChangeRecordValidate(entry))
            {
                return false;
            }

            try
            {
                this.AddChangeRecordPrep(entry);

                return this.AddChangeRecordProc(entry);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool AddChangeRecordValidate(EntityEntry entry)
        {
            if (!BACKEND_INFRA_API_CHANGERECORD_CHANGERECORD.ToLower().Equals(entry.Entity.GetType().ToString().ToLower()))
            {
                return false;
            }

            return true;
        }

        private void AddChangeRecordPrep(EntityEntry entry)
        {
            ((IBase)entry.Entity).Insertion = DateTime.Now;
            ((IBase)entry.Entity).Change = DateTime.Now;
        }

        private void ModifiedChangeRecordPrep(EntityEntry entry)
        {
            ((IBase)entry.Entity).Change = DateTime.Now;
        }

        private bool AddChangeRecordProc(EntityEntry entry)
        {
            var data = base.Add(entry.Entity);
            if (data == null || data == default)
            {
                return false;
            }

            if (data.Entity == null || data.Entity == default)
            {
                return false;
            }

            if (!typeof(IBase).IsAssignableFrom(data.Entity.GetType()))
            {
                return false;
            }

            if (((IBase)data.Entity).Id == null || ((IBase)data.Entity).Id == default)
            {
                return false;
            }

            return true;
        }

        private bool ModifiedChangeRecordProc(EntityEntry entry)
        {
            var data = base.Update(entry.Entity);
            if (data == null || data == default)
            {
                return false;
            }

            if (data.Entity == null || data.Entity == default)
            {
                return false;
            }

            if (!typeof(IBase).IsAssignableFrom(data.Entity.GetType()))
            {
                return false;
            }

            if (((IBase)data.Entity).Id == null || ((IBase)data.Entity).Id == default)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Data UPDATE flow
        /// </summary>
        /// <returns></returns>
        private void Modified()
        {
            var modified = _modified;
            if (!this.ModifiedValidate(modified))
            {
                return;
            }

            modified.ForEach(entry => ModifiedEntry(entry));
        }

        private bool ModifiedValidate(List<EntityEntry> modified)
        {
            if (modified == null || modified == default || modified.Count < 1)
            {
                return false;
            }

            return true;
        }

        private void ModifiedEntry(EntityEntry entry)
        {
            var prev = Mapper.CreateWithValues(entry.OriginalValues, entry.Entity.GetType());
            if (prev == null)
            {
                return;
            }

            if (!this.ModifiedEntryValidate(entry))
            {
                return;
            }

            if (this.ModifiedChangeRecord(entry))
            {
                return;
            }

            ((IBase)entry.Entity).Change = DateTime.Now;

            this.Tracker(entry);
        }

        private bool ModifiedChangeRecord(EntityEntry entry)
        {
            if (!this.ModifiedChangeRecordValidate(entry))
            {
                return false;
            }

            try
            {
                this.ModifiedChangeRecordPrep(entry);

                return this.ModifiedChangeRecordProc(entry);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ModifiedChangeRecordValidate(EntityEntry entry)
        {
            if (!BACKEND_INFRA_API_CHANGERECORD_CHANGERECORDTRACKER.ToLower().Equals(entry.Entity.GetType().ToString().ToLower()))
            {
                return false;
            }

            return true;
        }

        private bool ModifiedEntryValidate(EntityEntry entry)
        {
            if (entry == null || entry == default)
            {
                return false;
            }

            if (entry.Entity == null || entry.Entity == default)
            {
                return false;
            }

            if (!typeof(IBase).IsAssignableFrom(entry.Entity.GetType()))
            {
                return false;
            }

            if (((IBase)entry.Entity).PublisherId == default(Guid?))
            {
                return false;
            }

            return true;
        }

        private void Tracker(EntityEntry entry)
        {
            if (BACKEND_INFRA_API_CHANGERECORD_CHANGERECORD.ToLower().Equals(entry.Entity.GetType().ToString().ToLower()))
            {
                return;
            }

            if (BACKEND_INFRA_API_CHANGERECORD_CHANGERECORDTRACKER.ToLower().Equals(entry.Entity.GetType().ToString().ToLower()))
            {
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\n[{DateTime.Now}] ECRT trigged:");
            Console.ResetColor();

            ChangeRecord? entityChangeRecord = null;

            try
            {
                entityChangeRecord = this.GetChangeRecord(entry);
                if (entityChangeRecord == null || entityChangeRecord == default)
                {
                    return;
                }

                this.TrackPrevious(entityChangeRecord);

                var entryChangeRecord = base.Add(entityChangeRecord);
                if (entryChangeRecord == null || entryChangeRecord == default)
                {
                    return;
                }

                if (entryChangeRecord.Entity == null || entryChangeRecord.Entity == default)
                {
                    return;
                }

                entityChangeRecord = Mapper.SoftCopy<ChangeRecord>(entryChangeRecord.Entity);
                if (entityChangeRecord == null || entityChangeRecord.Id == default)
                {
                    return;
                }

                ChangeRecordTracker entityChangeRecordTracker = GetChangeRecordTracker(entityChangeRecord);
                if (entityChangeRecordTracker == null || entityChangeRecordTracker == default)
                {
                    return;
                }

                var entryChangeRecordTracker = base.Add(entityChangeRecordTracker);
                if (entryChangeRecordTracker == null || entryChangeRecordTracker == default)
                {
                    return;
                }

                if (entryChangeRecordTracker.Entity == null || entryChangeRecordTracker.Entity == default)
                {
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Type: ");
                Console.ResetColor();
                Console.WriteLine($"{entityChangeRecord.Name}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Record ID: ");
                Console.ResetColor();
                Console.WriteLine($"{entityChangeRecord.RecordIdentifier}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Previous:");
                Console.ResetColor();
                Console.WriteLine($"{entityChangeRecord.SerializedPrevious}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Current:");
                Console.ResetColor();
                Console.WriteLine($"{entityChangeRecord.SerializedCurrent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ECRT Exception:\n{ex.Message}");
            }
        }

        private ChangeRecordTracker GetChangeRecordTracker(ChangeRecord changeRecord)
        {
            ChangeRecordTracker tracker = new ChangeRecordTracker();
            tracker.Name = changeRecord.Name;
            tracker.RecordIdentifier = changeRecord.RecordIdentifier;
            tracker.ChangeRecordId = (Guid)changeRecord.Id;
            tracker.SerializedCurrentHash = Base.Infra.Cryptography.Crypto.SHA512(changeRecord.SerializedCurrent);
            tracker.SerializedPreviousHash = Base.Infra.Cryptography.Crypto.SHA512(changeRecord.SerializedPrevious);
            tracker.OwnerId = changeRecord.OwnerId;
            tracker.PublisherId = changeRecord.PublisherId;

            return tracker;
        }

        private ChangeRecord? GetChangeRecord(EntityEntry entry)
        {
            ChangeRecord record = new ChangeRecord();

            if (entry == null || entry == default)
            {
                throw new ArgumentNullException(nameof(entry), "Is null or default.");
            }

            var serializedPrevious = JsonConvert.SerializeObject(this.GetPrevious(entry));
            if (string.IsNullOrEmpty(serializedPrevious) || string.IsNullOrWhiteSpace(serializedPrevious))
            {
                throw new ArgumentNullException(nameof(serializedPrevious), "Is null or default.");
            }

            var serializedCurrent = JsonConvert.SerializeObject(entry.Entity);
            if (string.IsNullOrEmpty(serializedCurrent) || string.IsNullOrWhiteSpace(serializedCurrent))
            {
                throw new ArgumentNullException(nameof(serializedCurrent), "Is null or default.");
            }

            var iBase = ((IBase)entry.Entity);
            if (iBase == null || iBase == default)
            {
                throw new ArgumentNullException(nameof(iBase), "Is null or default.");
            }

            record.Name = entry.Entity.GetType().ToString();
            record.Insertion = DateTime.Now;
            record.SerializedPrevious = serializedPrevious;
            record.SerializedCurrent = serializedCurrent;
            record.RecordIdentifier = iBase.Id.GetValueOrDefault();
            record.OwnerId = iBase.OwnerId.GetValueOrDefault();
            record.PublisherId = iBase.PublisherId.GetValueOrDefault();

            return record;
        }

        public object? GetPrevious(EntityEntry entry)
        {
            if (this._previous != null && this._previous != default)
            {
                return this._previous;
            }

            var internalEntry = entry.OriginalValues.ToObject();
            if (internalEntry == null || internalEntry == default)
                return null;

            return internalEntry;
        }

        public override EntityEntry Update(object entity)
        {
            var result = base.Update(entity);

            return result;
        }

        public EntityEntry Update(object entity, object prev)
        {
            this._previous = prev;

            var result = base.Update(entity);

            return result;
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            var result = base.Update<TEntity>(entity);

            this._previous = Mapper.CreateWithValues(result.OriginalValues, result.Entity.GetType());

            return result;
        }

        public EntityEntry<TEntity> Update<TEntity>(TEntity entity, bool undo) where TEntity : class
        {
            var result = base.Update<TEntity>(entity);

            this._previous = this.AsNoTracking(entity.GetType(), ((IBase)entity).Id);

            return result;
        }

        private void TrackPrevious(ChangeRecord entity)
        {
            var last = this.ChangeRecord.Where(x => x.RecordIdentifier == entity.RecordIdentifier && x.State == true)?.FirstOrDefault();
            if (last == null || last == default)
            {
                return;
            }

            last.State = false;
            last.PublisherId = entity.PublisherId;
            last.Change = DateTime.Now;

            this.ChangeRecord.Update(last);
        }

        private object AsNoTracking(Type type, Guid? id)
        {
            object entity = default(object);

            try
            {
                entity = base.Find(type, id);
            }
            catch (Exception)
            {
                entity = default(object);
            }

            if (entity == null || entity == default(object))
            {
                return entity;
            }

            base.Entry(entity).State = EntityState.Detached;

            return Mapper.SoftCopy(entity, entity.GetType());
        }
    }
}