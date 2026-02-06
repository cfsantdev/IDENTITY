using Inventory.Controllers;
using Inventory.Models;
using Inventory.Models.Interfaces;
using Inventory.Models.Req;
using Inventory.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Inventory.Handlers
{
    public class RegistrationDataHandler : ControllerBase
    {
        private readonly ILogger<RegistrationDataController> _logger;
        private readonly InventoryDbContext _context;
        private readonly Apis _apis;

        protected RegistrationDataHandler(ILogger<RegistrationDataController> logger, InventoryDbContext context, Apis apis)
        {
            _logger = logger;
            _context = context;
            _apis = apis;
        }

        protected IActionResult Fetch()
        {
            List<RegistrationData> result = _context.RegistrationData.ToList();
            if (result == null || result == default || result.Count < 1)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult FetchById(FetchById filtro)
        {
            RegistrationData result = _context.RegistrationData.SingleOrDefault(x => x.Id == filtro.Id);
            if (result == null || result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected IActionResult Create(Create registry)
        {
            RegistrationData model = Mapper.ToAssign<Create, RegistrationData>(registry, Activator.CreateInstance<RegistrationData>());
            if (!this.CreateValidate(model, out string msg))
            {
                return ValidationProblem(msg);
            }

            EntityEntry<RegistrationData> result = _context.RegistrationData.Add(model);

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }

        protected IActionResult Update(Update registry)
        {
            RegistrationData target = _context.RegistrationData.SingleOrDefault(x => x.Id == registry.Id);
            if (target == null || target == default)
            {
                return NotFound();
            }

            EntityEntry<RegistrationData> result = _context.RegistrationData.Update(Mapper.ToAssign<Update, RegistrationData>(registry, target));

            int value = _context.SaveChanges();

            return Ok(result.Entity);
        }

        private bool CreateValidate(RegistrationData model, out string msg) {

            msg = string.Empty;

            if (model == null || model == default)
            {
                msg = "Model is null or default.";
                return false;
            }

            if (model.ItemId == default)
            {
                msg = "Invalid item identifier.";
                return false;
            }

            _apis.GetFromCatalog<dynamic>("/api/Item/Fetch", CreateValidateItem);

            return true;
        }

        private void CreateValidateItem(string serialized, dynamic instance)
        {
            if (string.IsNullOrEmpty(serialized) || string.IsNullOrWhiteSpace(serialized))
            {
                return;
            }

            if (instance == null || instance == default(dynamic))
            {
                return;
            }

            if (instance is JArray)
            {

            }

            Type type = instance.GetType();

            if (type == null)
            {

            }

            //foreach (PropertyInfo prop in instance.GetType().GetRuntimeProperties())
            //{

            //}
        }
    }
}
