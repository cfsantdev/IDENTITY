using Catalog.Controllers;
using Catalog.Utils;
using Entities.Public;
using Entities.Catalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Handlers
{
    public class RelItemCategoryHandler : ControllerBase
    {
        private readonly ILogger<RelItemCategoryController> _logger;
        private readonly CatalogDbContext _context;

        protected RelItemCategoryHandler(ILogger<RelItemCategoryController> logger, CatalogDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected IActionResult Fetch()
        {
            List<RelItemCategory> result = _context.RelItemCategory.Include(x => x.Item).Include(x => x.Category).ToList();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchById(FetchById filtro)
        {
            RelItemCategory result = _context.RelItemCategory.Include(x => x.Item).Include(x => x.Category).SingleOrDefault(x => x.Id == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchByItemId(FetchById filtro)
        {
            RelItemCategory result = _context.RelItemCategory.Include(x => x.Item).Include(x => x.Category).SingleOrDefault(x => x.ItemId == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchByCategoryId(FetchById filtro)
        {
            List<RelItemCategory> result = _context.RelItemCategory.Include(x => x.Item).Include(x => x.Category).Where(x => x.CategoryId == filtro.Id).ToList();
            if (result == null || result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult Create(CreateRel registry)
        {
            RelItemCategory entity = Mapper.ToAssign<CreateRel, RelItemCategory>(registry, Activator.CreateInstance<RelItemCategory>());
            EntityEntry<RelItemCategory> command = _context.RelItemCategory.Add(entity);

            int value = _context.SaveChanges();

            RelItemCategory result = _context.RelItemCategory.Include(x => x.Item).Include(x => x.Category).SingleOrDefault(x => x.Id == command.Entity.Id);

            return Ok(result);
        }

        protected IActionResult Update(UpdateRel registry)
        {
            RelItemCategory target = _context.RelItemCategory.SingleOrDefault(x => x.Id == registry.Id);
            if (target == null || target == default)
            {
                return NotFound();
            }

            EntityEntry<RelItemCategory> command = _context.RelItemCategory.Update(Mapper.ToAssign<UpdateRel, RelItemCategory>(registry, target));

            int value = _context.SaveChanges();

            RelItemCategory result = _context.RelItemCategory.Include(x => x.Item).Include(x => x.Category).SingleOrDefault(x => x.Id == command.Entity.Id);

            return Ok(result);
        }
    }
}
