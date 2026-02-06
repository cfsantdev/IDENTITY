using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.Documents.DocumentType;
using Backend.Infra.Identity.DTO.Documents.DocumentType;
using Identity.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Handlers.Interfaces
{
    public interface IDocumentTypeHandler
        : IIdentityHandler<DocumentTypeController, IdentityDbContext, DocumentType, DocumentTypeDTO>,
        IBaseHandlerCrud<DocumentTypeController, IdentityDbContext, DocumentType, DocumentTypeDTO>
    {
        new Task<IActionResult> FetchAsync();
        new Task<IActionResult> FetchByIdAsync(IFetchById filtro);
        new Task<IActionResult> DeleteByIdAsync(IFetchById filtro);

        Task<IActionResult> CreateAsync(CreateDocumentType registry);
        Task<IActionResult> UpdateAsync(UpdateDocumentType registry);
    }
}
