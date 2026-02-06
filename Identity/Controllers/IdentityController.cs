using AutoMapper;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Base.Interfaces;
using Backend.Infra.Identity.DbContext;
using Identity.Controllers.Interfaces;
using Identity.Handlers.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Identity.Controllers
{
    public class IdentityController<TController, THandler, TContext, TEntity, TEntityDTO> 
        : BaseControllerCrud<TController, THandler, TContext, TEntity, TEntityDTO>,
        IBaseControllerCrud<TController, THandler, TContext, TEntity, TEntityDTO>,
        IIdentityController<TController, THandler, TContext, TEntity, TEntityDTO>
        where TController : IControllerBase
        where THandler : IIdentityHandler<TController, TContext, TEntity, TEntityDTO>
        where TContext : IIdentityContext
        where TEntity : IBase
        where TEntityDTO : class
    {
        public IdentityController(ILogger<TController> logger, TContext context, IMapper mapper)
            : base((THandler)Activator.CreateInstance(typeof(THandler), logger, context, mapper))
        {
        }
    }
}
