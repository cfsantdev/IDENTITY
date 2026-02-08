using Backend.Infra.Api.Crud.Interfaces;
using System;

namespace Backend.Infra.Api.Crud
{
    public class CreateRel : ICreateRel
    {
        public Guid CoverId { get; set; }
        public Guid RelatedId { get; set; }
    }
}
