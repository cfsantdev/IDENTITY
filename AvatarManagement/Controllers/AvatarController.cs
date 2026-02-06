using AvatarManagement.Handlers;
using Entities.Public;
using Entities.Public.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AvatarManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvatarController : AvatarHandler
    {
        public AvatarController(ILogger<AvatarController> logger, AvatarManagementDbContext context) : base(logger, context)
        {
        }

        [HttpGet("Fetch")]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> Fetch()
        {
            return await base.FetchAsync();
        }

        [HttpPost("FetchById")]
        [Authorize(Roles = Roles.ADMIN_AND_OWNER)]
        public new IActionResult FetchById([FromBody] FetchById filtro)
        {
            return base.FetchById(filtro);
        }

        [HttpGet("GetDefault")]
        [Authorize(Roles = Roles.ADMIN_AND_OWNER)]
        public new IActionResult GetDefault()
        {
            return base.GetDefault();
        }
    }
}
