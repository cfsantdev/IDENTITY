using AutoMapper;
using Backend.Infra.Identity.DTO.Interfaces.Session;
using Backend.Infra.Identity.DTO.Session;
using Backend.Infra.Identity.Interfaces.Session;
using Backend.Infra.Identity.Session;

using ICreateSession = Backend.Infra.Identity.Interfaces.Session.ICreate;
using TSession = Backend.Infra.Identity.Session.Session;

namespace Backend.Infra.Identity.Extensions.AutoMapper
{
    public class SessionExtension : Backend.Infra.Extensions.AutoMapperTools.AutoMapperExtension, Backend.Infra.Extensions.AutoMapperTools.IAutoMapperExtension
    {
        public override void AddAutoMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ICreateSession, ISession>().ReverseMap();
            cfg.CreateMap<ISessionDTO, ISession>().ReverseMap();
            cfg.CreateMap<IUpdate, ISession>().ReverseMap();

            cfg.CreateMap<CreateSession, TSession>().ReverseMap();
            cfg.CreateMap<SessionDTO, TSession>().ReverseMap();
            cfg.CreateMap<UpdateSession, TSession>().ReverseMap();
        }
    }
}
