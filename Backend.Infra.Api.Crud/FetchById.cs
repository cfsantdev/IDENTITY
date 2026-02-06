using Backend.Infra.Api.Crud.Interfaces;
using System;

namespace Backend.Infra.Api.Crud
{
    public class FetchById : IFetchById
    {
        public Guid Id { get; set; }
        public Guid PublisherId { get; set; }
    }
}