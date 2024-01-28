using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProfileController(IProfileRepository profileRepository, IMapper mapper)
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
    }
}
