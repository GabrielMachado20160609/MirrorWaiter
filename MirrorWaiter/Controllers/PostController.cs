using Microsoft.AspNetCore.Mvc;
using MirrorWaiter.Domain.Model.PostAggregate;
using MirrorWaiter.Domain.Model.PostInfo;

namespace MirrorWaiter.Controllers
{
    [ApiController]
    [Route("posting")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] PostInfo info)
        {
            Post post;

            if(info.Image != null || info.Image.Length != 0)
            {
                post = new Post(info.UserId, info.Text, info.Image);
            }
            else
            {
                post = new Post(info.UserId, info.Text);
            }
            _postRepository.Add(post);
            return Ok(post);
        }
    }
}
