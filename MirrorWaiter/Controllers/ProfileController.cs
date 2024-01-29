using Microsoft.AspNetCore.Mvc;
using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Model.ProfileAggregate;

namespace MirrorWaiter.Controllers
{
    [ApiController]
    [Route("profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly AutoMapper.IMapper _mapper;

        public ProfileController(IProfileRepository profileRepository, AutoMapper.IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var profile = _mapper.Map<ProfileDTO>(_profileRepository.Get(id));
            return Ok(profile);
        }

        [HttpPost]
        public IActionResult AddProfile([FromBody] Profile profile)
        {
            _profileRepository.Add(profile);
            var profileDTO = _mapper.Map<ProfileDTO>(profile);
            return Ok(profileDTO);
        }
    }
}
