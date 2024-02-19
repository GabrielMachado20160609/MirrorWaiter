using MirrorWaiter.Domain.Model.CommentAggregate;

namespace MirrorWaiter.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ConnectionContext _connectionContext;

        public void Add(Comment comment)
        {
            _connectionContext.Comments.Add(comment);
            _connectionContext.SaveChanges();
        }

        public List<Comment> GetPostComments(int postId)
        {
            return _connectionContext.Comments.Where(x => x.post_id == postId).ToList();
        }

        public void Remove(Comment comment)
        {
            _connectionContext.Comments.Remove(comment);
            _connectionContext.SaveChanges();
        }

        public void Update(Comment comment)
        {
            _connectionContext.Comments.Update(comment);
            _connectionContext.SaveChanges();
        }
    }
}
