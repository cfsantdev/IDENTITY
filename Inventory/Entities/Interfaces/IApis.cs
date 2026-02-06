using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models.Interfaces
{
    public interface IApis
    {
        string Catalog { get; set; }
    }
}
