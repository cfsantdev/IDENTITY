using Catalog.Controllers;
using Catalog.Utils;
using Entities.Catalog;
using Entities.Public;
using Entities.Public.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Handlers
{
    public class SectionHandler : ControllerBase
    {
        private readonly ILogger<SectionController> _logger;
        private readonly CatalogDbContext _context;

        protected SectionHandler(ILogger<SectionController> logger, CatalogDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected IActionResult Fetch()
        {
            List<Section> result = _context.Sections.ToList();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchById(FetchById filtro)
        {
            Section result = _context.Sections.SingleOrDefault(x => x.Id == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchByName(FetchByName filtro)
        {
            List<Section> result = null;

            switch (filtro.FetchByNamePattern)
            {
                case FetchByNamePattern.STARTSWITH:
                    result = _context.Sections.Where(x => x.Name.ToLower().StartsWith(filtro.Name.ToLower())).ToList();
                    break;
                case FetchByNamePattern.CONTAINS:
                    result = _context.Sections.Where(x => x.Name.ToLower().Contains(filtro.Name.ToLower())).ToList();
                    break;
                case FetchByNamePattern.ENDSWITH:
                    result = _context.Sections.Where(x => x.Name.ToLower().EndsWith(filtro.Name.ToLower())).ToList();
                    break;
                default:
                    throw new Exception("Invalid search pattern.");
            }

            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult Create(Create registry)
        {
            Section model = Mapper.ToAssign<Create, Section>(registry, Activator.CreateInstance<Section>());
            EntityEntry<Section> result = _context.Sections.Add(model);

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }

        protected IActionResult Update(Update registry)
        {
            Section target = _context.Sections.SingleOrDefault(x => x.Id == registry.Id);
            if (target == null || target == default)
            {
                return NotFound();
            }

            EntityEntry<Section> result = _context.Sections.Update(Mapper.ToAssign<Update, Section>(registry, target));

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }

        protected IActionResult ChangeStatus(FetchById filtro)
        {
            Section model = _context.Sections.SingleOrDefault(x => x.Id == filtro.Id);
            if (model == null || model == default)
            {
                return NotFound("The model is not found.");
            }

            model.State = !model.State;

            EntityEntry<Section> result = _context.Sections.Update(model);

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }
    }
}
