using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.Documents.DocumentType;
using Backend.Infra.Identity.DTO.Documents.DocumentType;
using Identity.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Controllers.Interfaces
{
    public interface IDocumentTypeController
        : IIdentityController<DocumentTypeController, DocumentTypeHandler, IdentityDbContext, DocumentType, DocumentTypeDTO>,
        IBaseControllerCrud<DocumentTypeController, DocumentTypeHandler, IdentityDbContext, DocumentType, DocumentTypeDTO>
    {
        Task<IActionResult> Fetch();
        Task<IActionResult> FetchById([FromBody] FetchById filtro);
        Task<IActionResult> Create([FromBody] CreateDocumentType registry);
        Task<IActionResult> Update([FromBody] UpdateDocumentType registry);
        Task<IActionResult> DeleteById([FromBody] FetchById filtro);
    }
}
