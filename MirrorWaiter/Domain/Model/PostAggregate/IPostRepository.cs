using MirrorWaiter.Domain.DTOs;

namespace MirrorWaiter.Domain.Model.PostAggregate
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Update(Post post);
        void Remove(int id);
        List<FullPostDTO> GetFullUserPosts(int userId, int pageNumber, int pageQuantity);
    }
}
