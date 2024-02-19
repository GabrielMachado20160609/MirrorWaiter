namespace MirrorWaiter.Domain.DTOs
{
    public class CommentDTO
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}
