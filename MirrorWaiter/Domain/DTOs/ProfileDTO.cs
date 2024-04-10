using MirrorWaiter.Domain.Model.Enums;

namespace MirrorWaiter.Domain.DTOs
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public string Link { get; set; }
        public string ProfileImageS3Key { get; set; }
        public string BannerImage { get; set; }
    }
}
