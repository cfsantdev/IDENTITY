using AutoMapper;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.Interfaces.Profile;
using Identity.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Profile = Backend.Infra.Identity.Profile.Profile;

namespace Identity.Handlers
{
    public class IdentityHandler<TLogger, TContext, TEntity, TEntityDTO> : BaseHandlerCrud<TLogger, TContext, TEntity, TEntityDTO>, 
        IIdentityHandler<TLogger, TContext, TEntity, TEntityDTO>,
        IBaseHandlerCrud<TLogger, TContext, TEntity, TEntityDTO>
        where TLogger : IControllerBase
        where TContext : IIdentityContext
        where TEntity : Backend.Infra.Base.Base
        where TEntityDTO : class
    {
        public IdentityHandler(ILogger<TLogger> logger, TContext context, IMapper mapper, string publisher) :
            base(logger,
                context,
                mapper,
                publisher
            )
        {
        }

        public async Task<IActionResult> CreateAsync(TEntity registry)
        {
            if (!(await this.ProfileValidateAsync(registry.OwnerId)))
            {
                return Problem($"The 'OWNER' entered was not found. \nReview the information and resend the request, if the problem persists, contact support via email:");
            }

            return await base.CreateAsync<TEntity>(registry);
        }

        public async Task<bool> ProfileValidateAsync(Guid? ownerId)
        {
            try
            {
                var owner = await _context.Profile.SingleOrDefaultAsync(x => x.Id == ownerId);
                if (owner == null || owner == default || Guid.Empty.Equals(owner.Id))
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        protected override async Task<bool> PublisherValidate<TEntity>(TEntity entity)
        {
            var result = await base.PublisherValidate(entity);
            if (!result)
                return result;

            if (typeof(TEntity) == typeof(IProfile) || typeof(TEntity) == typeof(Profile))
                result = await this.PublisherValidateIdentity((IProfile)entity);

            return result;
        }

        private async Task<bool> PublisherValidateIdentity(IProfile profile)
        {
            var publisher = await _context.Profile.FirstOrDefaultAsync(x => x.Id == Guid.Parse(this._publisher));
            if (publisher == null || publisher == default)
                return true;

            if (publisher.OwnerId == profile.Id)
            {
                return false;
            }

            return true;
        }
    }
}