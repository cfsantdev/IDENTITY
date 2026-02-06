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
using System.Threading.Tasks;

namespace Catalog.Handlers
{
    public class ItemHandler : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly CatalogDbContext _context;

        protected ItemHandler(ILogger<ItemController> logger, CatalogDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected async Task<IActionResult> FetchAsync()
        {
            List<Item> result = _context.Itens.ToList();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchById(FetchById filtro)
        {
            Item result = _context.Itens.SingleOrDefault(x => x.Id == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchByName(FetchByName filtro)
        {
            List<Item> result = null;

            switch (filtro.FetchByNamePattern)
            {
                case FetchByNamePattern.STARTSWITH:
                    result = _context.Itens.Where(x => x.Name.ToLower().StartsWith(filtro.Name.ToLower())).ToList();
                    break;
                case FetchByNamePattern.CONTAINS:
                    result = _context.Itens.Where(x => x.Name.ToLower().Contains(filtro.Name.ToLower())).ToList();
                    break;
                case FetchByNamePattern.ENDSWITH:
                    result = _context.Itens.Where(x => x.Name.ToLower().EndsWith(filtro.Name.ToLower())).ToList();
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
            Item entity = Mapper.ToAssign<Create, Item>(registry, Activator.CreateInstance<Item>());
            EntityEntry<Item> result = _context.Itens.Add(entity);

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }

        protected IActionResult Update(Update registry)
        {
            Item target = _context.Itens.SingleOrDefault(x => x.Id == registry.Id);
            if (target == null || target == default)
            {
                return NotFound();
            }

            EntityEntry<Item> result = _context.Itens.Update(Mapper.ToAssign<Update, Item>(registry, target));

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }

        protected IActionResult ChangeStatus(FetchById filtro)
        {
            Item entity = _context.Itens.SingleOrDefault(x => x.Id == filtro.Id);
            if (entity == null || entity == default)
            {
                return NotFound("The model is not found.");
            }

            entity.State = !entity.State;

            EntityEntry<Item> result = _context.Itens.Update(entity);

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }
    }
}
