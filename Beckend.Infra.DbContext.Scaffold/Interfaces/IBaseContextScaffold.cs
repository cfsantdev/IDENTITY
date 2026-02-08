using Microsoft.EntityFrameworkCore;

namespace Beckend.Infra.DbContext.Scaffold.Interfaces
{
    public interface IBaseContextScaffold<TEntity>
        where TEntity : class
    {
        public static void Build(ModelBuilder builder, params TEntity[] data) => builder.Entity<TEntity>().HasData(data);
    }
}
