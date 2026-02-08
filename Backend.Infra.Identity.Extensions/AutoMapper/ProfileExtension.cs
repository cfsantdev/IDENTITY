using AutoMapper;
using Backend.Infra.Identity.DTO.Interfaces.Profile;
using Backend.Infra.Identity.DTO.Profile;
using Backend.Infra.Identity.Interfaces.Profile;
using Backend.Infra.Identity.Profile;
using Newtonsoft.Json.Linq;

using ICreateProfile = Backend.Infra.Identity.Interfaces.Profile.ICreate;
using TProfile = Backend.Infra.Identity.Profile.Profile;

namespace Backend.Infra.Identity.Extensions.AutoMapper
{
    public class ProfileExtension : Infra.Extensions.AutoMapperTools.AutoMapperExtension, Infra.Extensions.AutoMapperTools.IAutoMapperExtension
    {
        public override void AddAutoMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<IProfileDTO, IProfile>().ReverseMap();
            cfg.CreateMap<ICreateProfile, IProfile>().ReverseMap();
            cfg.CreateMap<IUpdateProfile, IProfile>().ReverseMap();

            cfg.CreateMap<object?, TProfile>().ReverseMap();
            cfg.CreateMap<object, TProfile>().ReverseMap();
            cfg.CreateMap<Object, TProfile>().ReverseMap();
            cfg.CreateMap<JObject, TProfile>().ReverseMap();
            cfg.CreateMap<ProfileDTO, TProfile>().ReverseMap();
            cfg.CreateMap<CreateProfile, TProfile>().ReverseMap();
            cfg.CreateMap<UpdateProfile, TProfile>().ReverseMap();
        }
    }
}
