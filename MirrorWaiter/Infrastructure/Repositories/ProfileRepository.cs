using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Model.ProfileAggregate;

namespace MirrorWaiter.Infrastructure.Repositories
{
    public class ProfileRepository: IProfileRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public void Add(Profile profile)
        {
            _connectionContext.Add(profile);
            _connectionContext.SaveChanges();
        }

        public List<ProfileDTO> Get(int pageNumber, int pageQuantity)
        {
            throw new NotImplementedException();
        }

        public Profile Get(int id)
        {
            return _connectionContext.Profiles.Find(id);
        }

        public Profile Update(Profile user)
        {
            throw new NotImplementedException();
        }
    }
}
