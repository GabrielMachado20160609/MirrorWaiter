namespace MirrorWaiter.Domain.Model.PostAggregate
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Update(Post post);
        void Remove(int id);
        List<Post> GetUserPosts(int userId, int pageNumber, int pageQuantity);
    }
}
