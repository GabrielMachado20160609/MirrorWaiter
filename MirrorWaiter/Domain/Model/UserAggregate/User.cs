using MirrorWaiter.Domain.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MirrorWaiter.Domain.Model.UserAggregate
{
    [Table("user")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string nickName { get; set; }
        public int age { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string bio { get; set; }
        public string country { get; set; }
        public Gender gender { get; set; }
        public string link { get; set; }
        public string profileImage { get; set; }
        public string bannerImage { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }

        public User() { }

        public User(string name, string nickName, 
            int age, string password, string email, 
            string bio, string country, Gender gender, 
            string link, string profileImage, string bannerImage)
        {
            this.name = name;
            this.nickName = nickName;
            this.age = age;
            this.password = password;
            this.email = email;
            this.bio = bio;
            this.country = country;
            this.gender = gender;
            this.link = link;
            this.profileImage = profileImage;
            this.bannerImage = bannerImage;
        }
    }
}
