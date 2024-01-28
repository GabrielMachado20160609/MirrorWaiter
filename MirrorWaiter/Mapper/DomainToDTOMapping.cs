using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Model.ProfileAggregate;

namespace MirrorWaiter.Mapper
{
    public class DomainToDTOMapping: AutoMapper.Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Profile, ProfileDTO>()
                .ForMember(dest => dest.NickName, map => map.MapFrom(origin => origin.nick_name))
                .ForMember(dest => dest.ProfileImage, map => map.MapFrom(origin => origin.profile_image))
                .ForMember(dest => dest.BannerImage, map => map.MapFrom(origin => origin.banner_image));
        }
    }
}
