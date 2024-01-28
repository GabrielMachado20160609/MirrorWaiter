using AutoMapper;
using MirrorWaiter.Domain.Model.UserAggregate;

namespace MirrorWaiter.Mapper
{
    public class DomainToDTOMapping: Profile
    {
        DomainToDTOMapping() 
        {
            CreateMap<User, UserDTO>()
        }
    }
}
