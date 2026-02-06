using Entities.Public.Interfaces;
using System;

namespace Entities.Public
{
    public class FetchById : IFetchById
    {
        public Guid Id { get; set; }
        public Guid PublisherId { get; set; }
    }
}