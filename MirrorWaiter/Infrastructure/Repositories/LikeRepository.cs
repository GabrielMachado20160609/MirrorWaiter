using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Model.LikeAggregate;
using MirrorWaiter.Domain.Exceptions;

namespace MirrorWaiter.Infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public int Add(Like like)
        {
            if(like.post_id <= 0 || like.user_id <= 0)
            {
                throw new RequiredInfoException("Missing information");
            }
            _connectionContext.Likes.Add(like);
            _connectionContext.SaveChanges();
            return LikesCount(like.post_id);
        }

        public int Remove(LikeDTO info)
        {
            var like = _connectionContext.Likes.Where(x => x.user_id == info.UserId && x.post_id == info.ContentId).FirstOrDefault();
            if(like == null)
            {
                throw new ItemNotFoundException("No matching data");
            }
            _connectionContext.Likes.Remove(like);
            _connectionContext.SaveChanges();
            return LikesCount(like.post_id);
        }

        public int LikesCount(int postId)
        {
            var post = _connectionContext.Posts.Find(postId);
            if(post == null)
            {
                throw new ItemNotFoundException("No matching data");
            }

            return _connectionContext.Likes.Where(x => x.post_id == postId).Count();
        }
    }
}
