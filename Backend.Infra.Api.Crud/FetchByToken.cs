using Backend.Infra.Api.Crud.Interfaces;
using System;

namespace Backend.Infra.Api.Crud
{
    public class FetchByToken : IFetchByToken
    {
        public string Token { get; set; }
        public Guid? PublisherId { get; set; }
    }
}
