using MirrorWaiter.Domain.Model.Enums;
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
        public string bio { get; set; }
        public string country { get; set; }
        public Gender gender { get; set; }
        public string link { get; set; }
        public string profile_image { get; set; }
        public string banner_image { get; set; }

        public Profile() { }

        public Profile(string name, string nick_name, 
            int age, string password, string email, 
            string bio, string country, Gender gender, 
            string link, string profile_image, string banner_image)
        {
            this.name = name;
            this.nick_name = nick_name;
            this.age = age;
            this.password = password;
            this.email = email;
            this.bio = bio;
            this.country = country;
            this.gender = gender;
            this.link = link;
            this.profile_image = profile_image;
            this.banner_image = banner_image;
        }
    }
}
