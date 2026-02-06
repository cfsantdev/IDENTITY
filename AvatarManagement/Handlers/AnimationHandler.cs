using Entities.AvatarManagement;
using Entities.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvatarManagement.Handlers
{
    public class AnimationHandler : ControllerBase
    {
        private readonly ILogger<AnimationHandler> _logger;
        private readonly AvatarManagementDbContext _context;

        protected AnimationHandler(ILogger<AnimationHandler> logger, AvatarManagementDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected async Task<IActionResult> FetchAsync()
        {
            List<Animation> result = _context.Animation.ToList();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchById(FetchById filtro)
        {
            Animation result = _context.Animation.SingleOrDefault(x => x.Id == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            _context.Entry<Animation>(result).Collection(x => x.AnimationStateCollection).Load();

            return Ok(result);
        }
    }
}
