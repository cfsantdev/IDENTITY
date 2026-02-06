using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Base.Interfaces;
using Beckend.Infra.DbContext;

namespace Backend.Infra.Api.Crud
{
    public class BaseControllerCrud<TController, THandler, TContext, TEntity, TEntityDTO> : BaseController,
        IBaseControllerCrud<TController, THandler, TContext, TEntity, TEntityDTO>,
        IControllerBase
        where TController : IControllerBase
        where THandler : IBaseHandlerCrud<TController, TContext, TEntity, TEntityDTO>
        where TContext : IBaseDbContext
        where TEntity : IBase
        where TEntityDTO : class
    {
        protected readonly THandler _handler;

        public BaseControllerCrud(THandler handler)
        {
            this._handler = handler;
        }
    }
}
