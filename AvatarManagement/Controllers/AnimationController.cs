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
    public class AnimationController : AnimationHandler
    {
        public AnimationController(ILogger<AnimationController> logger, AvatarManagementDbContext context) : base(logger, context)
        {
        }

        [HttpGet("Fetch")]
        [AllowAnonymous]
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
    }
}
