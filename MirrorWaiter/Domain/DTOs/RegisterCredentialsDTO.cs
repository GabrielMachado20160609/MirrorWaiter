using MirrorWaiter.Domain.Model.Enums;

namespace MirrorWaiter.Domain.DTOs
{
    public class RegisterCredentialsDTO
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public string ProfileImage { get; set; }
        public string BannerImage { get; set; }
    }
}
