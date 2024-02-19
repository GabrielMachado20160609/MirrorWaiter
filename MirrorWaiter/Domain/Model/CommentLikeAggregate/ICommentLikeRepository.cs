using MirrorWaiter.Domain.DTOs;

namespace MirrorWaiter.Domain.Model.CommentLikeAggregate
{
    public interface ICommentLikeRepository
    {
        int Add(CommentLike like);
        int Remove(LikeDTO info);
        int LikesCount(int postId);
    }
}
