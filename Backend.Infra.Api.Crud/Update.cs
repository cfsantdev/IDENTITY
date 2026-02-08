using Backend.Infra.Api.Crud.Interfaces;
using System;

namespace Backend.Infra.Api.Crud
{
    public class Update : IUpdate
    {
        public Guid? Id { get; set; }
        public Guid? PublisherId { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
