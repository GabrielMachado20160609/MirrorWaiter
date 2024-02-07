namespace MirrorWaiter.Domain.Model.LikeAggregate
{
    public interface ILikeRepository
    {
        int Add(Like like);
        int Remove(Like like);
        int LikesCount(int postId);
    }
}
