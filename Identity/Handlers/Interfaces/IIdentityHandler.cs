using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Base.Interfaces;
using Backend.Infra.Identity.DbContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Identity.Handlers.Interfaces
{
    public interface IIdentityHandler<TLogger, TContext, TEntity, TEntityDTO> : IBaseHandlerCrud<TLogger, TContext, TEntity, TEntityDTO>
        where TLogger : IControllerBase
        where TContext : IIdentityContext
        where TEntity : IBase
        where TEntityDTO : class
    {
        Task<IActionResult> CreateAsync(TEntity registry);
        Task<bool> ProfileValidateAsync(Guid? ownerId);
    }
}
