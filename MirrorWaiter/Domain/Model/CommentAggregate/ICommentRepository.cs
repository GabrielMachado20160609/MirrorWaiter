namespace MirrorWaiter.Domain.Model.CommentAggregate
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        void Update(Comment comment);
        void Remove(int commentId);
        List<Comment> GetPostComments(int postId, int pageNumber, int pageQuantity);
    }
}
