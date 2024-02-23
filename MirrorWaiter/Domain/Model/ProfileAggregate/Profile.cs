using MirrorWaiter.Domain.Model.CommentAggregate;
using MirrorWaiter.Domain.Model.CommentLikeAggregate;
using MirrorWaiter.Domain.Model.Enums;
using MirrorWaiter.Domain.Model.LikeAggregate;
using MirrorWaiter.Domain.Model.PostAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MirrorWaiter.Domain.Model.ProfileAggregate
{
    [Table("profile")]
    public class Profile
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string nick_name { get; set; }
        public int age { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string bio { get; set; } = "Hello, i'm using Mirror!";
        public string country { get; set; }
        public Gender gender { get; set; }
        public string link { get; set; } = "";
        public string profile_image { get; set; }
        public string banner_image { get; set; }

        public Profile() { }

        public Profile(string name, string nick_name, 
            int age, string password, string email, 
            string country, Gender gender, 
            string profile_image, string banner_image)
        {
            this.name = name;
            this.nick_name = nick_name;
            this.age = age;
            this.password = password;
            this.email = email;
            this.country = country;
            this.gender = gender;
            this.profile_image = profile_image;
            this.banner_image = banner_image;
        }
    }
}
