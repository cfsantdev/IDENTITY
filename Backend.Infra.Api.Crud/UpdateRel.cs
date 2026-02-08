using Backend.Infra.Api.Crud.Interfaces;
using System;

namespace Backend.Infra.Api.Crud
{
    public class UpdateRel : IUpdateRel
    {
        public Guid Id { get; set; }
        public Guid CoverId { get; set; }
        public Guid RelatedId { get; set; }
    }
}
