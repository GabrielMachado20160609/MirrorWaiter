using MirrorWaiter.Domain.DTOs;
using MirrorWaiter.Domain.Exceptions;
using MirrorWaiter.Domain.Model.CommentLikeAggregate;

namespace MirrorWaiter.Infrastructure.Repositories
{
    public class CommentLikeRepository : ICommentLikeRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public int Add(CommentLike like)
        {
            if (like.comment_id <= 0 || like.user_id <= 0)
            {
                throw new RequiredInfoException("Missing information");
            }
            _connectionContext.CommentLikes.Add(like);
            _connectionContext.SaveChanges();
            return LikesCount(like.comment_id);
        }

        public int Remove(LikeDTO info)
        {
            var like = _connectionContext.CommentLikes.Where(x => x.user_id == info.UserId && x.comment_id == info.ContentId).FirstOrDefault();
            if (like == null)
            {
                throw new ItemNotFoundException("No matching data");
            }
            _connectionContext.CommentLikes.Remove(like);
            _connectionContext.SaveChanges();
            return LikesCount(info.ContentId);
        }

        public int LikesCount(int commentId)
        {
            var post = _connectionContext.Comments.Find(commentId);
            if (post == null)
            {
                throw new ItemNotFoundException("No matching data");
            }

            return _connectionContext.CommentLikes.Where(x => x.comment_id == commentId).Count();
        }
    }
}
