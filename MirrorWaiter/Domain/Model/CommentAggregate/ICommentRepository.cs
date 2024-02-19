namespace MirrorWaiter.Domain.Model.CommentAggregate
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        void Update(Comment comment);
        void Remove(Comment comment);
        List<Comment> GetPostComments(int postId);
    }
}
