using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Exceptions;
using MirrorWaiter.Domain.Model.Enums;
using MirrorWaiter.Domain.Model.ProfileAggregate;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

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

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var profile = _mapper.Map<ProfileDTO>(_profileRepository.Get(id));
                return Ok(profile);
            }
            catch(ItemNotFoundException e)
            {
                return BadRequest(e);
            }
            catch(RequiredInfoException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult AddProfile([FromBody] RegisterCredentialsDTO credentials)
        {
            try
            {
                Profile profile = new Profile(
                credentials.Name,
                credentials.NickName,
                credentials.Age,
                credentials.Password,
                credentials.Email,
                credentials.Country,
                credentials.Gender,
                credentials.ProfileImage,
                credentials.BannerImage
            );
                _profileRepository.Add(profile);
                var profileDTO = _mapper.Map<ProfileDTO>(profile);
                return Ok(profileDTO);
            }
            catch(AlreadyExistsException e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [Route("update/{id}")]
        [HttpPost]
        public IActionResult UpdateProfile([FromBody] Profile profile)
        {
            try
            {
                _profileRepository.Update(profile);
                var profileDTO = _mapper.Map<ProfileDTO>(profile);
                return Ok(profileDTO);
            }
            catch(ItemNotFoundException e)
            {
                return BadRequest(e);
            }
        }
    }
}
