using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Talepler;

namespace WebApplication1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Talep> Talepler { get; set; }
    }
}
