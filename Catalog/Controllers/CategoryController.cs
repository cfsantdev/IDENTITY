using Catalog.Handlers;
using Entities.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CategoryHandler
    {
        public CategoryController(ILogger<CategoryController> logger, CatalogDbContext context) : base(logger, context)
        {
        }

        [HttpGet("Fetch")]
        public new IActionResult Fetch()
        {
            return base.Fetch();
        }

        [HttpPost("FetchById")]
        public new IActionResult FetchById([FromBody] FetchById filtro)
        {
            return base.FetchById(filtro);
        }

        [HttpPost("FetchByName")]
        public new IActionResult FetchByName([FromBody] FetchByName filtro)
        {
            return base.FetchByName(filtro);
        }

        [HttpPost("Create")]
        public new IActionResult Create([FromBody]Create registry)
        {
            return base.Create(registry);
        }

        [HttpPut("Update")]
        public new IActionResult Update([FromBody]Update registry)
        {
            return base.Update(registry);
        }

        [HttpPut("ChangeStatus")]
        public new IActionResult ChangeStatus([FromBody]FetchById filtro)
        {
            return base.ChangeStatus(filtro);
        }
    }
}
