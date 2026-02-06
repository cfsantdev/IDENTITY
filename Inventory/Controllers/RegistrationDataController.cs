using Inventory.Handlers;
using Inventory.Models;
using Inventory.Models.Interfaces;
using Inventory.Models.Req;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Inventory.Controllers
{
    public class RegistrationDataController : RegistrationDataHandler
    {
        public RegistrationDataController(ILogger<RegistrationDataController> logger, InventoryDbContext context, Apis apis) : base(logger, context, apis)
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

        [HttpPost("Create")]
        public new IActionResult Create([FromBody] Create registry)
        {
            return base.Create(registry);
        }

        [HttpPut("Update")]
        public new IActionResult Update([FromBody] Update registry)
        {
            return base.Update(registry);
        }
    }
}
