using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Exceptions;
using MirrorWaiter.Domain.Model.CommentAggregate;
using MirrorWaiter.Domain.Model.CommentLikeAggregate;

namespace MirrorWaiter.Controllers
{
    [ApiController]
    [Route("{postId}/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentLikeRepository _commentLikeRepository;

        public CommentController(ICommentRepository commentRepository, ICommentLikeRepository commentLikeRepository)
        {
            _commentRepository = commentRepository;
            _commentLikeRepository = commentLikeRepository;
        }

        //Comments route
        [Authorize]
        [HttpPost]
        public IActionResult AddComment([FromBody] CommentDTO info)
        {
            try
            {
                Comment comm = new Comment(info.UserId, info.Text, info.PostId);
                _commentRepository.Add(comm);
                return Ok(comm);
            }
            catch (RequiredInfoException e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [Route("{id}/update")]
        [HttpPost]
        public IActionResult UpdateComment([FromBody] Comment comment)
        {
            try
            {
                _commentRepository.Update(comment);
                return Ok(comment);
            }
            catch(RequiredInfoException e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [Route("{id}/remove")]
        [HttpPost]
        public IActionResult RemoveComment(int id)
        {
            try
            {
                _commentRepository.Remove(id);
                return Ok();
            }
            catch (ItemNotFoundException e)
            {
                return BadRequest(e);
            }
            catch (RequiredInfoException e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [Route("{postId}-{pageNumber}-{pageQuantity}")]
        [HttpGet]
        public IActionResult GetPostComments(int postId, int pageNumber, int pageQuantity)
        {
            try
            {
                var posts = _commentRepository.GetPostComments(postId, pageNumber, pageQuantity);
                return Ok(posts);
            }
            catch (RequiredInfoException e)
            {
                return BadRequest(e);
            }
        }


        //Comment likes route
        [Authorize]
        [Route("{id}/like_count")]
        [HttpGet]
        public IActionResult CommentLikeCount(int commentId)
        {
            var count = _commentLikeRepository.LikesCount(commentId);
            return Ok(count);
        }

        [Authorize]
        [Route("{id}/like")]
        [HttpPost]
        public IActionResult CommentLikeAdd([FromBody] LikeDTO info)
        {
            CommentLike like = new CommentLike(info.UserId, info.ContentId);
            _commentLikeRepository.Add(like);
            return Ok();
        }

        [Authorize]
        [Route("{id}/like/remove")]
        [HttpPost]
        public IActionResult CommentLikeRemove([FromBody] LikeDTO info)
        {
            _commentLikeRepository.Remove(info);
            return Ok();
        }
    }
}
