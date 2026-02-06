using AutoMapper;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.Documents.DocumentType;
using Backend.Infra.Identity.DTO.Documents.DocumentType;
using Identity.Controllers;
using Identity.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Identity.Handlers
{
    public class DocumentTypeHandler 
        : IdentityHandler<DocumentTypeController, IdentityDbContext, DocumentType, DocumentTypeDTO>,
        IIdentityHandler<DocumentTypeController, IdentityDbContext, DocumentType, DocumentTypeDTO>,
        IBaseHandlerCrud<DocumentTypeController, IdentityDbContext, DocumentType, DocumentTypeDTO>,
        IDocumentTypeHandler
    {
        public DocumentTypeHandler(ILogger<DocumentTypeController> logger, IdentityDbContext context, IMapper mapper)
            : base(logger,
                  context,
                  mapper,
                  context.PUBLISHER_SETTINGS.DocumentTypePublisher
            )
        {
        }

        public async new Task<IActionResult> FetchAsync() => await base.FetchAsync();
        public async new Task<IActionResult> FetchByIdAsync(IFetchById filtro) => await base.FetchByIdAsync(filtro);
        public async new Task<IActionResult> DeleteByIdAsync(IFetchById filtro) => await base.DeleteByIdAsync(filtro);

        public async Task<IActionResult> CreateAsync(CreateDocumentType registry) => await base.CreateAsync(registry);
        public async Task<IActionResult> UpdateAsync(UpdateDocumentType registry) => await base.UpdateAsync(registry);
    }
}
