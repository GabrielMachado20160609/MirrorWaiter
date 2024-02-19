using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MirrorWaiter.Domain.DTOs;
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
        private readonly ICommentRepository _commentRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly ICommentLikeRepository _commentLikeRepository;

        public PostController(
            IPostRepository postRepository, 
            ICommentRepository commentRepository, 
            ILikeRepository likeRepository, 
            ICommentLikeRepository commentLikeRepository
            )
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _likeRepository = likeRepository;
            _commentLikeRepository = commentLikeRepository;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] PostInfoDTO info)
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

        [Authorize]
        [Route("{id}/update")]
        [HttpPost]
        public IActionResult Update([FromBody] Post post)
        {
            _postRepository.Update(post);
            return Ok(post);
        }

        [Authorize]
        [Route("{id}/remove")]
        [HttpPost]
        public IActionResult Remove([FromBody] Post post)
        {
            _postRepository.Remove(post);
            return Ok();
        }


        //Likes route
        [Authorize]
        [Route("{postId}/like_count")]
        [HttpGet]
        public IActionResult LikeCount(int postId)
        {
            var count = _likeRepository.LikesCount(postId);
            return Ok(count);
        }

        [Authorize]
        [Route("{postId}/like")]
        [HttpPost]
        public IActionResult Like([FromBody] LikeDTO info)
        {
            Like like = new Like(info.UserId, info.ContentId);
            _likeRepository.Add(like);
            return Ok();
        }

        [Authorize]
        [Route("{postId}/like/remove")]
        [HttpPost]
        public IActionResult LikeRemove([FromBody] LikeDTO info)
        {
            _likeRepository.Remove(info);
            return Ok();
        }


        //Comments route
        [Authorize]
        [Route("{postId}/comment")]
        [HttpPost]
        public IActionResult AddComment([FromBody] CommentDTO info)
        {
            Comment comm = new Comment(info.UserId, info.Text, info.PostId);
            _commentRepository.Add(comm);
            return Ok(comm);
        }

        [Authorize]
        [Route("{postId}/comment/{id}/update")]
        [HttpPost]
        public IActionResult UpdateComment([FromBody] Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok(comment);
        }

        [Authorize]
        [Route("{postId}/comment/{id}/remove")]
        [HttpPost]
        public IActionResult RemoveComment([FromBody] Comment comment)
        {
            _commentRepository.Remove(comment);
            return Ok(comment);
        }


        //Comment likes route
        [Authorize]
        [Route("{postId}/comment/{id}/like_count")]
        [HttpGet]
        public IActionResult CommentLikeCount(int commentId)
        {
            var count = _commentLikeRepository.LikesCount(commentId);
            return Ok(count);
        }

        [Authorize]
        [Route("{postId}/comment/{id}/like")]
        [HttpPost]
        public IActionResult CommentLike([FromBody] LikeDTO info)
        {
            CommentLike like = new CommentLike(info.UserId, info.ContentId);
            _commentLikeRepository.Add(like);
            return Ok();
        }

        [Authorize]
        [Route("{postId}/comment/{id}/like")]
        [HttpPost]
        public IActionResult CommentLikeRemove([FromBody] LikeDTO info)
        {
            _commentLikeRepository.Remove(info);
            return Ok();
        }
    }
}
