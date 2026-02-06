using AutoMapper;
using Backend.Infra.Api.ChangeRecord;
using Backend.Infra.Api.ChangeRecord.DTO;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Identity.Controllers;
using Identity.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Identity.Handlers
{
    public class ChangeRecordTrackerHandler : IdentityHandler<ChangeRecordTrackerController, IdentityDbContext, ChangeRecordTracker, ChangeRecordTrackerDTO>,
        IIdentityHandler<ChangeRecordTrackerController, IdentityDbContext, ChangeRecordTracker, ChangeRecordTrackerDTO>,
        IBaseHandlerCrud<ChangeRecordTrackerController, IdentityDbContext, ChangeRecordTracker, ChangeRecordTrackerDTO>,
        IChangeRecordTrackerHandler
    {
        public ChangeRecordTrackerHandler(ILogger<ChangeRecordTrackerController> logger, IdentityDbContext context, IMapper mapper)
            : base(logger,
                  context,
                  mapper,
                  context.PUBLISHER_SETTINGS.RecordChangeTrackerPublisher)
        {
        }

        new public async Task<IActionResult> FetchAsync() => await base.FetchAsync();
        new public async Task<IActionResult> FetchByIdAsync(IFetchById filtro) => await base.FetchByIdAsync(filtro);
        new public async Task<IActionResult> FetchByNameAsync(IFetchByName filtro) => await base.FetchByNameAsync(filtro);
    }
}
