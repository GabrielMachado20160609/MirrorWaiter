using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Exceptions;
using MirrorWaiter.Domain.Model.CommentAggregate;
using MirrorWaiter.Domain.Model.CommentLikeAggregate;
using MirrorWaiter.Domain.Model.LikeAggregate;
using MirrorWaiter.Domain.Model.PostAggregate;

namespace MirrorWaiter.Controllers
{
    [ApiController]
    [Route("posting")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly ILikeRepository _likeRepository;

        public PostController(
            IPostRepository postRepository,
            ILikeRepository likeRepository
            )
        {
            _postRepository = postRepository;
            _likeRepository = likeRepository;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] PostInfoDTO info)
        {
            try
            {
                Post post;

                if (info.Image != null || info.Image.Length != 0)
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
            catch (RequiredInfoException e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [Route("{id}/update")]
        [HttpPost]
        public IActionResult Update([FromBody] Post post)
        {
            try
            {
                _postRepository.Update(post);
                return Ok(post);
            }
            catch(RequiredInfoException e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [Route("{id}/remove")]
        [HttpPost]
        public IActionResult Remove(int id)
        {
            try
            {
                _postRepository.Remove(id);
                return Ok();
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

        [Authorize]
        [Route("{userId}-{pageNumber}-{pageQuantity}")]
        [HttpGet]
        public IActionResult GetUserPosts(int id, int pageNumber, int pageQuantity)
        {
            try
            {
                var posts = _postRepository.GetUserPosts(id, pageNumber, pageQuantity);
                return Ok(posts);
            }
            catch(RequiredInfoException e)
            {
                return BadRequest(e);
            }
        }


        //Likes route
        [Authorize]
        [Route("{postId}/like_count")]
        [HttpGet]
        public IActionResult LikeCount(int postId)
        {
            try
            {
                var count = _likeRepository.LikesCount(postId);
                return Ok(count);
            }
            catch(ItemNotFoundException e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [Route("{postId}/like")]
        [HttpPost]
        public IActionResult Like([FromBody] LikeDTO info)
        {
            try
            {
                Like like = new Like(info.UserId, info.ContentId);
                _likeRepository.Add(like);
                return Ok();
            }
            catch(RequiredInfoException e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [Route("{postId}/like/remove")]
        [HttpPost]
        public IActionResult LikeRemove([FromBody] LikeDTO info)
        {
            try
            {
                _likeRepository.Remove(info);
                return Ok();
            }
            catch(ItemNotFoundException e)
            {
                return BadRequest(e);
            }
        }
    }
}
