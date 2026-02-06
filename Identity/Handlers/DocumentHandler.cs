using AutoMapper;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.Documents.Document;
using Backend.Infra.Identity.DTO.Documents;
using Backend.Infra.Identity.DTO.Profile;
using Identity.Controllers;
using Identity.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using TProfile = Backend.Infra.Identity.Profile.Profile;

namespace Identity.Handlers
{
    public class DocumentHandler 
        : IdentityHandler<DocumentController, IdentityDbContext, Document, DocumentDTO>,
        IIdentityHandler<DocumentController, IdentityDbContext, Document, DocumentDTO>,
        IBaseHandlerCrud<DocumentController, IdentityDbContext, Document, DocumentDTO>,
        IDocumentHandler
    {
        public DocumentHandler(ILogger<DocumentController> logger, IdentityDbContext context, IMapper mapper) : 
            base(logger, 
                context, 
                mapper, 
                context.PUBLISHER_SETTINGS.DocumentPublisher
            )
        {
        }

        public async new Task<IActionResult> FetchAsync() => await base.FetchAsync();
        public async new Task<IActionResult> FetchByIdAsync(IFetchById filtro) => await base.FetchByIdAsync(filtro);

        public async Task<IActionResult> CreateAsync(CreateDocument registry) => await base.CreateAsync(registry);
        public async Task<IActionResult> UpdateAsync(UpdateDocument registry) => await base.UpdateAsync(registry);
    }
}
