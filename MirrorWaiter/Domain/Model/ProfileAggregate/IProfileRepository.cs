using MirrorWaiter.Domain.DTOs;

namespace MirrorWaiter.Domain.Model.ProfileAggregate
{
    public interface IProfileRepository
    {
        void Add(Profile profile);
        Profile Update(Profile profile);
        List<ProfileDTO> Get(int pageNumber, int pageQuantity);
        Profile Get(int id);
    }
}
