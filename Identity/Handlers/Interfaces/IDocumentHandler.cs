using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.Documents.Document;
using Backend.Infra.Identity.DTO.Documents;
using Identity.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Handlers.Interfaces
{
    public interface IDocumentHandler
        : IIdentityHandler<DocumentController, IdentityDbContext, Document, DocumentDTO>,
        IBaseHandlerCrud<DocumentController, IdentityDbContext, Document, DocumentDTO>
    {
        new Task<IActionResult> FetchAsync();
        new Task<IActionResult> FetchByIdAsync(IFetchById filtro);

        Task<IActionResult> CreateAsync(CreateDocument registry);
        Task<IActionResult> UpdateAsync(UpdateDocument registry);
    }
}
