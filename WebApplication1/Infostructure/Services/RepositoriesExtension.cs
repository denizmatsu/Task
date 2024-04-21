using WebApplication1.Repository;

namespace WebApplication1.Infostructure.Services
{
    public static class RepositoriesExtension
    {
        public static WebApplicationBuilder AddAppRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ITaleplerRepository, TaleplerRepository>();

            return builder;
        }
    }
}
