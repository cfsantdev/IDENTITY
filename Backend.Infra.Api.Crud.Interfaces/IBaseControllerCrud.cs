using Backend.Infra.Base.Interfaces;
using Beckend.Infra.DbContext;

namespace Backend.Infra.Api.Crud.Interfaces
{
    public interface IBaseControllerCrud<TController, THandler, TContext, TEntity, TEntityDTO>
        where TController : IControllerBase
        where THandler : IBaseHandlerCrud<TController, TContext, TEntity, TEntityDTO>
        where TContext : IBaseDbContext
        where TEntity : IBase
        where TEntityDTO : class
    {
    }
}
