using Catalog.Handlers;
using Entities.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelItemCategoryController : RelItemCategoryHandler
    {
        public RelItemCategoryController(ILogger<RelItemCategoryController> logger, CatalogDbContext context) : base(logger, context)
        {
        }

        [HttpGet("Fetch")]
        public new IActionResult Fetch()
        {
            return base.Fetch();
        }

        [HttpPost("FetchById")]
        public new IActionResult FetchById([FromBody]FetchById filtro)
        {
            return base.FetchById(filtro);
        }

        [HttpPost("FetchByItemId")]
        public new IActionResult FetchByItemId([FromBody] FetchById filtro)
        {
            return base.FetchByItemId(filtro);
        }

        [HttpPost("FetchByCategoryId")]
        public new IActionResult FetchByCategoryId([FromBody] FetchById filtro)
        {
            return base.FetchByCategoryId(filtro);
        }

        [HttpPost("Create")]
        public new IActionResult Create([FromBody] CreateRel registry)
        {
            return base.Create(registry);
        }

        [HttpPut("Update")]
        public new IActionResult Update([FromBody] UpdateRel registry)
        {
            return base.Update(registry);
        }
    }
}