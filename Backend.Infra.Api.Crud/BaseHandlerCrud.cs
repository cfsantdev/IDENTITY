using AutoMapper;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Base.Interfaces;
using Backend.Infra.Enumerators;
using Beckend.Infra.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace Backend.Infra.Api.Crud
{
    public class BaseHandlerCrud<TController, TContext, TEntity, TEntityDTO> : ControllerBase,
        IBaseHandlerCrud<TController, TContext, TEntity, TEntityDTO>
        where TController : IControllerBase
        where TContext : IBaseDbContext
        where TEntity : Base.Base
        where TEntityDTO : class
    {
        protected readonly ILogger<TController> _logger;
        protected readonly TContext _context;
        protected readonly IMapper _mapper;
        protected readonly string _publisher;

        public BaseHandlerCrud(ILogger<TController> logger, TContext context, IMapper mapper, string publisher)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _publisher = publisher;
        }

        public virtual async Task<IActionResult> FetchAsync()
        {
            var result = await _context.Set<TEntity>().ToListAsync<TEntity>();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound($"The '{typeof(TEntity).Name}' not found. \nReview the information and resend the request, if the problem persists, contact support via email:");
            }

            List<TEntityDTO> dto = _mapper.Map<List<TEntity>, List<TEntityDTO>>(result);
            if (dto == null || dto == default || dto.Count < 1)
            {
                return Problem($"Casting error from {nameof(List<TEntityDTO>)}.");
            }

            return Ok(dto);
        }

        public virtual async Task<IActionResult> FetchByIdAsync(IFetchById filtro)
        {
            TEntity? result = await _context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound($"The '{typeof(TEntity).Name}' not found. \nReview the information and resend the request, if the problem persists, contact support via email:");
            }

            TEntityDTO dto = _mapper.Map<TEntity, TEntityDTO>(result);
            if (dto == null || dto == default)
            {
                return base.Problem($"Casting error from {nameof(TEntityDTO)}.");
            }

            return Ok(result);
        }

        public virtual async Task<IActionResult> FetchByNameAsync(IFetchByName filtro)
        {
            List<TEntityDTO>? result = null;
            List<TEntity>? query = null;

            if (!(typeof(TEntity) is IBaseNamed))
            {
                throw new Exception($"The entity '{typeof(TEntity).Name}' is unamed.");
            }

            switch (filtro.FetchByNamePattern)
            {
                case FetchByNamePattern.STARTSWITH:
                    query = await _context.Set<TEntity>().Where(x => ((IBaseNamed)x).Name.ToLower().StartsWith(filtro.Name.ToLower())).ToListAsync();
                    break;
                case FetchByNamePattern.CONTAINS:
                    query = await _context.Set<TEntity>().Where(x => ((IBaseNamed)x).Name.ToLower().Contains(filtro.Name.ToLower())).ToListAsync();
                    break;
                case FetchByNamePattern.ENDSWITH:
                    query = await _context.Set<TEntity>().Where(x => ((IBaseNamed)x).Name.ToLower().EndsWith(filtro.Name.ToLower())).ToListAsync();
                    break;
                default:
                    throw new Exception("Invalid search pattern.");
            }

            if (query == null || query == default || query.Count < 1)
            {
                return NotFound();
            }

            List<TEntityDTO> dto = _mapper.Map<List<TEntity>, List<TEntityDTO>>(query);
            if (dto == null || dto == default || dto.Count < 1)
            {
                return Problem($"Casting error from {nameof(TEntityDTO)}.");
            }

            return Ok(result);
        }

        public virtual async Task<IActionResult> CreateAsync<TEntityCreate>(TEntityCreate command)
        {
            TEntity entity = _mapper.Map<TEntityCreate, TEntity>(command, Activator.CreateInstance<TEntity>());

            // Get publisher
            if (await this.PublisherValidate<TEntity>(entity))
            {
                entity.PublisherId = this.PublisherIdentifier(this._publisher);
            }

            EntityEntry<TEntity> result = await _context.Set<TEntity>().AddAsync(entity);

            int value = await _context.SaveChangesAsync();

            var dto = _mapper.Map<TEntity, TEntityDTO>(result.Entity);
            if (dto == null || dto == default)
            {
                return Problem($"Casting error from {nameof(TEntityDTO)}.");
            }

            return Ok(dto);
        }

        public virtual async Task<IActionResult> UpdateAsync<TEntityUpdate>(TEntityUpdate command)
        {
            TEntity? update = this._mapper.Map<TEntityUpdate, TEntity>(command);
            if (update == null || update == default)
            {
                return Problem($"Casting error from {nameof(TEntityUpdate)}.");
            }

            TEntity? entity = await this._context.Set<TEntity>().AsNoTracking<TEntity>().SingleOrDefaultAsync(x => x.Id == update.Id);
            if (entity == null || entity == default)
            {
                return NotFound($"The '{typeof(TEntity).Name}' not found. \nReview the information and resend the request, if the problem persists, contact support via email:");
            }

            // Get publisher
            if (await this.PublisherValidate<TEntity>(entity))
            {
                update.PublisherId = this.PublisherIdentifier(this._publisher);
            }

            EntityEntry<TEntity> result = _context.Set<TEntity>().Update(update);

            int value = _context.SaveChanges();

            var dto = _mapper.Map<TEntityDTO>(result.Entity);
            if (dto == null || dto == default)
            {
                return Problem($"Casting error from {nameof(TEntityDTO)}.");
            }

            return Ok(dto);
        }

        public virtual async Task<IActionResult> DeleteByIdAsync(IFetchById filtro)
        {
            TEntity? entity = await _context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == filtro.Id);
            if (entity == null || entity == default)
            {
                return NotFound("The 'SESSION' not found. \nReview the information and resend the request, if the problem persists, contact support via email:");
            }

            entity.PublisherId = this.PublisherIdentifier(this._publisher);

            _context.Set<TEntity>().Remove(entity);

            int value = _context.SaveChanges();

            return Ok(value);
        }

        public virtual async Task<IActionResult> ChangeStateByIdAsync(IFetchById filtro)
        {
            TEntity? entity = await _context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == filtro.Id);
            if (entity == null || entity == default)
            {
                return NotFound("The 'SESSION' not found. \nReview the information and resend the request, if the problem persists, contact support via email:");
            }

            entity.PublisherId = this.PublisherIdentifier(this._publisher);
            ((IBaseStateful)entity).State = !((IBaseStateful)entity).State;

            EntityEntry<TEntity> result = _context.Set<TEntity>().Update(entity);

            int value = _context.SaveChanges();

            var dto = _mapper.Map<TEntityDTO>(result.Entity);
            if (dto == null || dto == default)
            {
                return Problem($"Casting error from {nameof(TEntityDTO)}.");
            }

            return Ok(dto);
        }

        public virtual Guid? PublisherIdentifier(string publisher) => Guid.Parse(_publisher);

        protected virtual async Task<bool> PublisherValidate<TEntity>(TEntity entity) where TEntity : IBase => (!string.IsNullOrEmpty(this._publisher) && !string.IsNullOrWhiteSpace(this._publisher));
    }
}
