using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Exceptions;
using MirrorWaiter.Domain.Model.CommentAggregate;
using MirrorWaiter.Domain.Model.LikeAggregate;
using MirrorWaiter.Domain.Model.PostAggregate;

namespace MirrorWaiter.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();
        private readonly LikeRepository _likeRepository = new LikeRepository();
        private readonly CommentRepository _commentRepository = new CommentRepository();

        public void Add(Post post)
        {
            if (post.text.Length < 0 || post.text == null || post.user_id <= 0)
            {
                throw new RequiredInfoException("Missing information");
            }

            _connectionContext.Posts.Add(post);
            _connectionContext.SaveChanges();
        }

        public void Remove(int id)
        {
            if (id <= 0) throw new RequiredInfoException("Missing id");

            Post post = _connectionContext.Posts.Where(x => x.id == id).FirstOrDefault();
            if (post != null)
            {
                _connectionContext.Posts.Remove(post);
                _connectionContext.SaveChanges();
            }
            else
            {
                throw new ItemNotFoundException("Post not found");
            }
        }

        public void Update(Post post)
        {
            if (post.text.Length < 0 || post.text == null || post.user_id <= 0)
            {
                throw new RequiredInfoException("Missing information");
            }

            _connectionContext.Posts.Update(post);
            _connectionContext.SaveChanges();
        }

        public List<FullPostDTO> GetFullUserPosts(int userId, int pageNumber, int pageQuantity)
        {
            if(userId <= 0 || pageQuantity <= 0 || pageNumber <= 0)
            {
                throw new RequiredInfoException("Invalid information");
            }

            List<Post> posts = _connectionContext.Posts
                .Where(x => x.user_id == userId)
                .Skip(pageNumber - 1 * pageQuantity)
                .Take(pageQuantity).ToList();

            List<FullPostDTO> fullUserPosts = new List<FullPostDTO>();

            if (posts.Count > 0)
            {
                foreach (Post post in posts)
                {
                    int likesCount = _likeRepository.LikesCount(post.id);
                    Comment firstComment = _commentRepository.GetPostComments(post.id, 1, 1).FirstOrDefault();
                    fullUserPosts.Add(new FullPostDTO
                    {
                        Post = post,
                        LikesCount = likesCount,
                        FirstComment = firstComment
                    });
                }
            }

            return fullUserPosts;
        }
    }
}
