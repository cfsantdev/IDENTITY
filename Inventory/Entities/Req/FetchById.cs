using Inventory.Models.Req.Interfaces;
using System;

namespace Inventory.Models.Req
{
    public class FetchById : IFetchById
    {
        public Guid Id { get; set; }
    }
}