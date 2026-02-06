using Backend.Infra.Identity.DTO.Profile;
using AutoMapper.Configuration;

namespace Backend.Infra.Identity.DTO.Profiles.Profile
{
    public class AMProfileDTO : Identity.Profile.Profile
    {
        public AMProfileDTO()
        {
            AutoMapper.Execution.CreateMap<ProfileDTO, Identity.Profile.Profile>();
        }
    }
}
