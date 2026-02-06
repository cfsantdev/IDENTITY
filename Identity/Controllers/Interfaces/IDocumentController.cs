using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.Documents.Document;
using Backend.Infra.Identity.DTO.Documents;
using Identity.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Controllers.Interfaces
{
    public interface IDocumentController
        : IIdentityController<DocumentController, DocumentHandler, IdentityDbContext, Document, DocumentDTO>,
        IBaseControllerCrud<DocumentController, DocumentHandler, IdentityDbContext, Document, DocumentDTO>
    {
        Task<IActionResult> Fetch();
        Task<IActionResult> FetchById([FromBody] FetchById filtro);
        Task<IActionResult> Create([FromBody] CreateDocument registry);
        Task<IActionResult> Update([FromBody] UpdateDocument registry);
    }
}
