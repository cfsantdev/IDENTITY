using Entities.AvatarManagement;
using Entities.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvatarManagement.Handlers
{
    public class AnimationStateHandler : ControllerBase
    {
        private readonly ILogger<AnimationStateHandler> _logger;
        private readonly AvatarManagementDbContext _context;

        protected AnimationStateHandler(ILogger<AnimationStateHandler> logger, AvatarManagementDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected async Task<IActionResult> FetchAsync()
        {
            List<AnimationState> result = _context.AnimationState.ToList();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            return Ok(result);
        }
        protected IActionResult FetchById(FetchById filtro)
        {
            AnimationState result = _context.AnimationState.SingleOrDefault(x => x.Id == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            _context.Entry<AnimationState>(result).Collection(x => x.AnimationStateItemCollection).Load();

            return Ok(result);
        }
    }
}
