using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Model.CommentLikeAggregate;

namespace MirrorWaiter.Infrastructure.Repositories
{
    public class CommentLikeRepository : ICommentLikeRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public int Add(CommentLike like)
        {
            _connectionContext.CommentLikes.Add(like);
            _connectionContext.SaveChanges();
            return LikesCount(like.comment_id);
        }

        public int Remove(LikeDTO info)
        {
            var like = _connectionContext.CommentLikes.Where(x => x.user_id == info.UserId && x.comment_id == info.ContentId).FirstOrDefault();
            if(like != null)
            {
                _connectionContext.CommentLikes.Remove(like);
                _connectionContext.SaveChanges();
            }
            return LikesCount(info.ContentId);
        }

        public int LikesCount(int postId)
        {
            return _connectionContext.CommentLikes.Where(x => x.comment_id == postId).Count();
        }
    }
}
