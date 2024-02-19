using Microsoft.AspNetCore.Mvc;
using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Model.ProfileAggregate;
using MirrorWaiter.Infrastructure;

namespace MirrorWaiter.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;

        public AuthController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpPost]
        public IActionResult Index([FromBody] AuthCredentialsDTO credentials)
        {
            var profileWithToken = _profileRepository.Authenticate(credentials.Email, credentials.Password);
            if (profileWithToken != null)
            {
                return Ok(profileWithToken);
            }
            else return BadRequest();
        }
    }
}
