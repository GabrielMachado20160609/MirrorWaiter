using MirrorWaiter.Application.Services;
using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Exceptions;
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
            else
            {
                throw new AlreadyExistsException("Email already registered");
            }
        }

        public List<ProfileDTO> Get(int pageNumber, int pageQuantity)
        {
            if(pageNumber  < 1 || pageQuantity < 1)
            {
                throw new RequiredInfoException("Invalid information");
            }

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
            if(id < 1)
            {
                throw new RequiredInfoException("Invalid information");
            }

            var item = _connectionContext.Profiles.Find(id);
            if(item == null)
            {
                throw new ItemNotFoundException("No profile found");
            }

            return item;
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
            if (profile == null)
            {
                throw new ItemNotFoundException("User not found");
            }

            var token = TokenService.GenerateToken(profile);
            return new
            {
                token,
                profile
            };
        }
    }
}
