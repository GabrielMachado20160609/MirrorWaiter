using MirrorWaiter.Domain.Model.PostAggregate;
using MirrorWaiter.Domain.Model.ProfileAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MirrorWaiter.Domain.Model.LikeAggregate
{
    [Table("likes")]
    public class Like
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public int post_id { get; set; }

        public Like() { }
    
        public Like(int user_id, int post_id)
        {
            this.user_id = user_id;
            this.post_id = post_id;
        }
    }
}
