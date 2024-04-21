using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Talepler
{
    public class CommentDTO
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
}
