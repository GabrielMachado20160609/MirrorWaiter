using MirrorWaiter.Domain.DTOs;

namespace MirrorWaiter.Domain.Model.LikeAggregate
{
    public interface ILikeRepository
    {
        int Add(Like like);
        int Remove(LikeDTO info);
        int LikesCount(int postId);
    }
}
