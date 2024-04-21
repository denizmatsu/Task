namespace WebApplication1.Infostructure.Services
{
    public static class ControllersExtension
    {
        public static WebApplicationBuilder AddAppControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();

            return builder;
        }
    }
}
