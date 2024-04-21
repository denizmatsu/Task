using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infostructure.Services
{
    public static class DbContextExtension
    {
        public static WebApplicationBuilder AddAppDbContext(this WebApplicationBuilder builder)
        {
            IConfiguration configuration = builder.Configuration;

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));


            return builder;
        }
    }
}
