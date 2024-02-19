using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MirrorWaiter.Domain.Model.CommentAggregate
{
    [Table("comments")]
    public class Comment
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public int post_id { get; set; }
        public string text { get; set; }

        public Comment() { }

        public Comment(int user_id, string text, int post_id)
        {
            this.user_id = user_id;
            this.text = text;
            this.post_id = post_id;
        }
    }
}
