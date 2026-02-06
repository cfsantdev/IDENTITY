using AutoMapper;
using Backend.Infra.Api.ChangeRecord;
using Backend.Infra.Api.ChangeRecord.DTO;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Assemblies;
using Backend.Infra.Identity.DbContext;
using Identity.Controllers;
using Identity.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Identity.Handlers
{
    public class ChangeRecordHandler : IdentityHandler<ChangeRecordController, IdentityDbContext, ChangeRecord, ChangeRecordDTO>,
        IIdentityHandler<ChangeRecordController, IdentityDbContext, ChangeRecord, ChangeRecordDTO>,
        IBaseHandlerCrud<ChangeRecordController, IdentityDbContext, ChangeRecord, ChangeRecordDTO>,
        IChangeRecordHandler
    {
        public ChangeRecordHandler(ILogger<ChangeRecordController> logger, IdentityDbContext context, IMapper mapper)
            : base(logger,
                  context,
                  mapper,
                  context.PUBLISHER_SETTINGS.RecordChangePublisher)
        {
        }

        public async Task<IActionResult> UndoAsync(FetchById filtro)
        {
            ChangeRecord entity = await _context.ChangeRecord.SingleOrDefaultAsync(x => x.Id == filtro.Id && x.State.Equals(true));
            if (entity == null || entity == default)
            {
                return NotFound();
            }

            var type = AssembliesManagement.i.GetType(entity.Name);

            var changeRecordDto = this._mapper.Map<ChangeRecordDTO>(entity);
            var previous = changeRecordDto.Previous(out Type previousType);
            var current = changeRecordDto.Current(out Type currentType);
            var changes = _context.Update(
                previous,
                current
            );

            _context.SaveChanges();

            entity.State = false;

            var result = _context.ChangeRecord.Update(entity);

            _context.SaveChanges();

            var dto = _mapper.Map<ChangeRecordDTO>(result.Entity);
            if (changeRecordDto == null || changeRecordDto == default)
            {
                return Problem($"Casting error from {nameof(ChangeRecordDTO)}.");
            }

            return Ok(changeRecordDto);
        }
    }
}
