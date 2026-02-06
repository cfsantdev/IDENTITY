using Entities.Public.Interfaces;
using System;

namespace Entities.Public
{
    public class FetchByToken : IFetchByToken
    {
        public string Token { get; set; }
        public Guid? PublisherId { get; set; }
    }
}
