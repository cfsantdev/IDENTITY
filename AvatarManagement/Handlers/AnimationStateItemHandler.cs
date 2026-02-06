using Entities.AvatarManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvatarManagement.Handlers
{
    public class AnimationStateItemHandler : ControllerBase
    {
        private readonly ILogger<AnimationStateItemHandler> _logger;
        private readonly AvatarManagementDbContext _context;

        protected AnimationStateItemHandler(ILogger<AnimationStateItemHandler> logger, AvatarManagementDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected async Task<IActionResult> FetchAsync()
        {
            List<AnimationStateItem> result = _context.AnimationStateItem.ToList();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
