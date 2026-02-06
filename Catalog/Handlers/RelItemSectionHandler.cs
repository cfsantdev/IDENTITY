using Catalog.Controllers;
using Catalog.Utils;
using Entities.Catalog;
using Entities.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Handlers
{
    public class RelItemSectionHandler : ControllerBase
    {
        private readonly ILogger<RelItemSectionController> _logger;
        private readonly CatalogDbContext _context;

        protected RelItemSectionHandler(ILogger<RelItemSectionController> logger, CatalogDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected IActionResult Fetch()
        {
            List<RelItemSection> result = _context.RelItemSection.Include(x => x.Item).Include(x => x.Section).ToList();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchById(FetchById filtro)
        {
            RelItemSection result = _context.RelItemSection.Include(x => x.Item).Include(x => x.Section).SingleOrDefault(x => x.Id == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchByItemId(FetchById filtro)
        {
            RelItemSection result = _context.RelItemSection.Include(x => x.Item).Include(x => x.Section).SingleOrDefault(x => x.ItemId == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchBySectionId(FetchById filtro)
        {
            List<RelItemSection> result = _context.RelItemSection.Include(x => x.Item).Include(x => x.Section).Where(x => x.SectionId == filtro.Id).ToList();
            if (result == null || result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult Create(CreateRel registry)
        {
            RelItemSection entity = Mapper.ToAssign<CreateRel, RelItemSection>(registry, Activator.CreateInstance<RelItemSection>());
            EntityEntry<RelItemSection> command = _context.RelItemSection.Add(entity);

            int value = _context.SaveChanges();

            RelItemSection result = _context.RelItemSection.Include(x => x.Item).Include(x => x.Section).SingleOrDefault(x => x.Id == command.Entity.Id);

            return Ok(result);
        }

        protected IActionResult Update(UpdateRel registry)
        {
            RelItemSection target = _context.RelItemSection.SingleOrDefault(x => x.Id == registry.Id);
            if (target == null || target == default)
            {
                return NotFound();
            }

            EntityEntry<RelItemSection> command = _context.RelItemSection.Update(Mapper.ToAssign<UpdateRel, RelItemSection>(registry, target));

            int value = _context.SaveChanges();

            RelItemSection result = _context.RelItemSection.Include(x => x.Item).Include(x => x.Section).SingleOrDefault(x => x.Id == command.Entity.Id);

            return Ok(result);
        }
    }
}
