using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Talepler
{
    public class TalepListesiDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Complaint { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
