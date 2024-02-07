using MirrorWaiter.Domain.Model.LikeAggregate;

namespace MirrorWaiter.Infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public int Add(Like like)
        {
            _connectionContext.Likes.Add(like);
            _connectionContext.SaveChanges();
            return LikesCount(like.post_id);
        }

        public int Remove(Like like)
        {
            _connectionContext.Likes.Remove(like);
            _connectionContext.SaveChanges();
            return LikesCount(like.post_id);
        }

        public int LikesCount(int postId)
        {
            return _connectionContext.Likes.Where(x => x.post_id == postId).Count();
        }
    }
}
