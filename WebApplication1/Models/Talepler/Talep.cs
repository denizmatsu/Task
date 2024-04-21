using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Talepler
{
    public class Talep
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public int CustomerId { get; set; }
        [Required]
        public required string Complaint { get; set; }
    }
}
