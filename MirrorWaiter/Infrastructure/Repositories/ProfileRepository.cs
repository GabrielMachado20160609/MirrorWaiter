using MirrorWaiter.Application.Services;
using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Model.ProfileAggregate;

namespace MirrorWaiter.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public void Add(Profile profile)
        {
            if (!_connectionContext.Profiles.Where(x => x.email == profile.email).Any())
            {
                _connectionContext.Profiles.Add(profile);
                _connectionContext.SaveChanges();
            }
        }

        public List<ProfileDTO> Get(int pageNumber, int pageQuantity)
        {

            return _connectionContext.Profiles
                .Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(x => new ProfileDTO
                {
                    Id = x.id,
                    Name = x.name,
                    NickName = x.nick_name,
                    Email = x.email,
                    ProfileImage = x.profile_image,
                    BannerImage = x.banner_image,
                    Country = x.country,
                    Bio = x.bio,
                    Gender = x.gender,
                    Link = x.link,
                    Age = x.age,
                }).ToList();
        }

        public Profile Get(int id)
        {
            return _connectionContext.Profiles.Find(id);
        }

        public Profile Update(Profile profile)
        {
            _connectionContext.Update(profile);
            _connectionContext.SaveChanges();
            return profile;
        }

        public object Authenticate(string email, string password)
        {
            var profile = _connectionContext.Profiles.Where(user => user.email == email && user.password == password).SingleOrDefault();
            if (profile != null)
            {
                var token = TokenService.GenerateToken(profile);

                return new
                {
                    token,
                    profile
                };
            }
            else return null;
        }
    }
}
