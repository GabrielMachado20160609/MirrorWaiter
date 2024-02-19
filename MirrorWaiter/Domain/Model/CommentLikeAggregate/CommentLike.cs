using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MirrorWaiter.Domain.Model.CommentLikeAggregate
{
    [Table("comment_likes")]
    public class CommentLike
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public int comment_id { get; set; }

        public CommentLike() { }

        public CommentLike(int user_id, int post_id)
        {
            this.user_id = user_id;
            comment_id = post_id;
        }
    }
}

