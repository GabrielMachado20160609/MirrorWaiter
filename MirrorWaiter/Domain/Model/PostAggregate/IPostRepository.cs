namespace MirrorWaiter.Domain.Model.PostAggregate
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Update(Post post);
        void Remove(Post post);
        List<Post> GetUserPosts(int userId);
    }
}
