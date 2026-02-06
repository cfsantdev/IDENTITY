using Backend.Infra.Api.ChangeRecord;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Beckend.Infra.DbContext
{
    public interface IBaseDbContext : IDisposable
    {
        event EventHandler<SavingChangesEventArgs>? SavingChanges;
        event EventHandler<SavedChangesEventArgs>? SavedChanges;
        event EventHandler<SaveChangesFailedEventArgs>? SaveChangesFailed;

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet<TEntity> Set<TEntity>(string name) where TEntity : class;

        DbSet<ChangeRecord>? ChangeRecord { get; set; }
        DbSet<ChangeRecordTracker>? ChangeRecordTracker { get; set; }

        object? GetPrevious(EntityEntry entry);

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        EntityEntry Add(object entity);
        EntityEntry Entry(object entity);
        EntityEntry Update(object entity);
        EntityEntry Update(object entity, object prev);
        void AddRange(params object[] entities);
        Task AddRangeAsync(params object[] entities);
        void AttachRange(params object[] entities);
        void UpdateRange(params object[] entities);
        void RemoveRange(params object[] entities);
        void AddRange(IEnumerable<object> entities);
        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);
        void AttachRange(IEnumerable<object> entities);
        void UpdateRange(IEnumerable<object> entities);
        void RemoveRange(IEnumerable<object> entities);
        object? Find(Type entityType, params object?[]? keyValues);
        ValueTask<object?> FindAsync(Type entityType, params object?[]? keyValues);
        ValueTask<object?> FindAsync(Type entityType, object?[]? keyValues, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity, bool undo) where TEntity : class;
        TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class;
        ValueTask<TEntity?> FindAsync<TEntity>(params object?[]? keyValues) where TEntity : class;
        ValueTask<TEntity?> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellationToken) where TEntity : class;
        IQueryable<TResult> FromExpression<TResult>(Expression<Func<IQueryable<TResult>>> expression);
    }
}
