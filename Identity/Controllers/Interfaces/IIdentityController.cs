using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Base.Interfaces;
using Beckend.Infra.DbContext;

namespace Identity.Controllers.Interfaces
{
    public interface IIdentityController<TController, THandler, TContext, TEntity, TEntityDTO> 
        : IBaseControllerCrud<TController, THandler, TContext, TEntity, TEntityDTO>
        where TController : IControllerBase
        where THandler : IBaseHandlerCrud<TController, TContext, TEntity, TEntityDTO>
        where TContext : IBaseDbContext
        where TEntity : IBase
        where TEntityDTO : class
    {
    }
}
