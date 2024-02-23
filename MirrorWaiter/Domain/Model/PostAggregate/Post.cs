using MirrorWaiter.Domain.Model.CommentAggregate;
using MirrorWaiter.Domain.Model.LikeAggregate;
using MirrorWaiter.Domain.Model.ProfileAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MirrorWaiter.Domain.Model.PostAggregate
{
    [Table("posts")]
    public class Post
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string? image { get; set; } = "";
        public string text { get; set; }

        public Post() { }

        public Post(int user_id, string text)
        {
            this.user_id = user_id;
            this.text = text;
        }

        public Post(int user_id, string text, string image)
        {
            this.user_id = user_id;
            this.image = image;
            this.text = text;
        }
    }
}
