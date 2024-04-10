using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Model.ProfileAggregate;

namespace MirrorWaiter.Application.Mapper
{
    public class DomainToDTOMapping : AutoMapper.Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Profile, ProfileDTO>()
                .ForMember(dest => dest.NickName, map => map.MapFrom(origin => origin.nick_name))
                .ForMember(dest => dest.ProfileImageS3Key, map => map.MapFrom(origin => origin.profile_image_s3_key))
                .ForMember(dest => dest.BannerImage, map => map.MapFrom(origin => origin.banner_image));
        }
    }
}
