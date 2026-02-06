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
    public class CategoryHandler : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly CatalogDbContext _context;

        protected CategoryHandler(ILogger<CategoryController> logger, CatalogDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected IActionResult Fetch()
        {
            List<Category> result = _context.Categories.ToList();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchById(FetchById filtro)
        {
            Category result = _context.Categories.SingleOrDefault(x => x.Id == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchByName(FetchByName filtro)
        {
            List<Category> result = null;

            switch (filtro.FetchByNamePattern)
            {
                case FetchByNamePattern.STARTSWITH:
                    result = _context.Categories.Where(x => x.Name.ToLower().StartsWith(filtro.Name.ToLower())).ToList();
                    break;
                case FetchByNamePattern.CONTAINS:
                    result = _context.Categories.Where(x => x.Name.ToLower().Contains(filtro.Name.ToLower())).ToList();
                    break;
                case FetchByNamePattern.ENDSWITH:
                    result = _context.Categories.Where(x => x.Name.ToLower().EndsWith(filtro.Name.ToLower())).ToList();
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
            Category entity = Mapper.ToAssign<Create, Category>(registry, Activator.CreateInstance<Category>());
            EntityEntry<Category> result = _context.Categories.Add(entity);

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }

        protected IActionResult Update(Update registry)
        {
            Category target = _context.Categories.SingleOrDefault(x => x.Id == registry.Id);
            if (target == null || target == default)
            {
                return NotFound();
            }

            EntityEntry<Category> result = _context.Categories.Update(Mapper.ToAssign<Update,Category>(registry, target));

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }

        protected IActionResult ChangeStatus(FetchById filtro)
        {
            Category entity = _context.Categories.SingleOrDefault(x => x.Id == filtro.Id);
            if (entity == null || entity == default)
            {
                return NotFound("The model is not found.");
            }

            entity.State = !entity.State;

            EntityEntry<Category> result = _context.Categories.Update(entity);

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }
    }
}
