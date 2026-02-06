using AvatarManagement.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AvatarManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimationStateItemController : AnimationStateItemHandler
    {
        public AnimationStateItemController(ILogger<AnimationStateItemController> logger, AvatarManagementDbContext context) : base(logger, context)
        {
        }

        [HttpGet("Fetch")]
        [AllowAnonymous]
        public async Task<IActionResult> Fetch()
        {
            return await base.FetchAsync();
        }
    }
}
