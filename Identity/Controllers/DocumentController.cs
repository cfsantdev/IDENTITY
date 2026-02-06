using AutoMapper;
using Backend.Infra.Api.Crud;
using Backend.Infra.Api.Crud.Interfaces;
using Backend.Infra.Exceptions.Internal;
using Backend.Infra.Identity.DbContext;
using Backend.Infra.Identity.Documents.Document;
using Backend.Infra.Identity.DTO.Documents;
using Backend.Infra.Identity.DTO.Documents.DocumentType;
using Identity.Controllers.Interfaces;
using Identity.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : IdentityController<DocumentController, DocumentHandler, IdentityDbContext, Document, DocumentDTO>,
        IIdentityController<DocumentController, DocumentHandler, IdentityDbContext, Document, DocumentDTO>,
        IBaseControllerCrud<DocumentController, DocumentHandler, IdentityDbContext, Document, DocumentDTO>,
        IDocumentController
    {
        public DocumentController(ILogger<DocumentController> logger, IdentityDbContext context, IMapper mapper) 
            : base(logger, context, mapper)
        {
        }

        [HttpGet("Fetch")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DocumentTypeDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Fetch()
        {
            try
            {
                return await this._handler.FetchAsync();
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<DocumentController, Exception>(nameof(Fetch), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("FetchById")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentTypeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchById([FromBody] FetchById filtro)
        {
            try
            {
                return await this._handler.FetchByIdAsync(filtro);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<DocumentController, Exception>(nameof(FetchById), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPost("Create")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] CreateDocument registry)
        {
            try
            {
                return await this._handler.CreateAsync(registry);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<DocumentController, Exception>(nameof(this._handler.CreateAsync), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }

        [HttpPut("Update")]
        [Authorize(Roles = "ADMIN,MANAGER,SUPERVISOR,REGULAR,READONLY")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateDocument registry)
        {
            try
            {
                return await this._handler.UpdateAsync(registry);
            }
            catch (Exception ex)
            {
                using (var e = new BaseException<DocumentController, Exception>(nameof(this._handler.UpdateAsync), ex))
                {
                    e.Display();
                }

                return Problem(ex.Message);
            }
        }
    }
}
