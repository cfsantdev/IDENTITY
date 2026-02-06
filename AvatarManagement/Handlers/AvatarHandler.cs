using Entities.AvatarManagement;
using Entities.Public;
using Entities.Public.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AvatarManagement.Handlers
{
    public class AvatarHandler : ControllerBase
    {
        private readonly ILogger<AvatarHandler> _logger;
        private readonly AvatarManagementDbContext _context;

        protected AvatarHandler(ILogger<AvatarHandler> logger, AvatarManagementDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected async Task<IActionResult> FetchAsync()
        {
            List<Avatar> result = _context.Avatar.ToList();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            //result.ForEach(avatar => 
            //{
            //    _context.Entry<Avatar>(avatar).Collection(x => x.AnimationCollection).Load();
            //
            //    avatar.AnimationCollection.ToList().ForEach(animation => 
            //    {
            //        _context.Entry<Animation>(animation).Collection(x => x.AnimationStateCollection).Load();
            //
            //        animation.AnimationStateCollection.ToList().ForEach(animationState =>
            //        {
            //            _context.Entry<AnimationState>(animationState).Collection(x => x.AnimationStateItemCollection).Load();
            //        });
            //    });
            //});

            return Ok(result);
        }

        protected IActionResult GetDefault()
        {
            Avatar result = _context.Avatar.FirstOrDefault();
            if (result == null || result == default)
            {
                return NotFound();
            }

            _context.Entry<Avatar>(result).Collection(x => x.AnimationCollection).Load();

            result.AnimationCollection.ToList().ForEach(animation =>
            {
                _context.Entry<Animation>(animation).Collection(x => x.AnimationStateCollection).Load();

                animation.AnimationStateCollection.ToList().ForEach(animationState =>
                {
                    _context.Entry<AnimationState>(animationState).Collection(x => x.AnimationStateItemCollection).Load();
                });
            });

            return Ok(result);
        }

        protected IActionResult FetchById(FetchById filtro)
        {
            Avatar result = _context.Avatar.SingleOrDefault(x => x.Id == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            _context.Entry<Avatar>(result).Collection(x => x.AnimationCollection).Load();

            return Ok(result);
        }
    }
}
