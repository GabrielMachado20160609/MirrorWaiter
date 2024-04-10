using Microsoft.AspNetCore.Mvc;
using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Exceptions;
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
            try
            {
                var profileWithToken = _profileRepository.Authenticate(credentials.Email, credentials.Password);
                return Ok(profileWithToken);
            }
            catch(ItemNotFoundException e)
            {
                return BadRequest(e);
            }
        }
    }
}
