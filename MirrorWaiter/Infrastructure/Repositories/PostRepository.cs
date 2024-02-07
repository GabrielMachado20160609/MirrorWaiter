using MirrorWaiter.Domain.Model.PostAggregate;

namespace MirrorWaiter.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public void Add(Post post)
        {
            _connectionContext.Posts.Add(post);
            _connectionContext.SaveChanges();
        }

        public void Remove(Post post)
        {
            _connectionContext.Posts.Remove(post);
            _connectionContext.SaveChanges();
        }

        public void Update(Post post)
        {
            _connectionContext.Posts.Update(post);
            _connectionContext.SaveChanges();
        }

        public List<Post> GetUserPosts(int userId)
        {
            return _connectionContext.Posts.Where(x => x.user_id == userId).ToList();
        }
    }
}
