using MirrorWaiter.Domain.Exceptions;
using MirrorWaiter.Domain.Model.CommentAggregate;

namespace MirrorWaiter.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public void Add(Comment comment)
        {
            if (comment.post_id <= 0 || comment.user_id <= 0 || comment.text.Length == 0 || comment.text == null)
            {
                throw new RequiredInfoException("Missing information");
            }

            _connectionContext.Comments.Add(comment);
            _connectionContext.SaveChanges();
        }

        public List<Comment> GetPostComments(int postId, int pageNumber, int pageQuantity)
        {
            if(postId <= 0)
            {
                throw new RequiredInfoException("Invalid information");
            }

            return _connectionContext.Comments.Where(x => x.post_id == postId).Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
        }

        public void Remove(int commentId)
        {
            if (commentId <= 0) throw new RequiredInfoException("Missing id");

            Comment comment = _connectionContext.Comments.Where(x => x.id == commentId).FirstOrDefault();
            if (comment != null)
            {
                _connectionContext.Comments.Remove(comment);
                _connectionContext.SaveChanges();
            }
            else
            {
                throw new ItemNotFoundException("Comment not found");
            }
        }

        public void Update(Comment comment)
        {
            if (comment.post_id <= 0 || comment.user_id <= 0 || comment.text.Length == 0 || comment.text == null)
            {
                throw new RequiredInfoException("Missing information");
            }

            _connectionContext.Comments.Update(comment);
            _connectionContext.SaveChanges();
        }
    }
}
