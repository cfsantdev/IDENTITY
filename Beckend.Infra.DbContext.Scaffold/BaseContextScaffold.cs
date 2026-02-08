using Beckend.Infra.DbContext.Scaffold.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Beckend.Infra.DbContext.Scaffold
{
    public class BaseContextScaffold<TEntity> : IBaseContextScaffold<TEntity>
        where TEntity : class
    {
        public static void Build(ModelBuilder builder, params TEntity[] data) => builder.Entity<TEntity>().HasData(data);
    }
}
