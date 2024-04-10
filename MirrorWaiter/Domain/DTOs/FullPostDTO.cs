using MirrorWaiter.Domain.Model.CommentAggregate;
using MirrorWaiter.Domain.Model.LikeAggregate;
using MirrorWaiter.Domain.Model.PostAggregate;

namespace MirrorWaiter.Domain.DTOs
{
    public class FullPostDTO
    {
        public Post Post { get; set; }
        public ProfileMinDTO Author { get; set; }
        public int LikesCount { get; set; }
        public Comment FirstComment { get; set; }
        public ProfileMinDTO Commenter { get; set; }
    }
}
