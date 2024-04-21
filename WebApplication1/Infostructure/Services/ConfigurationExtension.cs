namespace WebApplication1.Infostructure.Services
{
    public static class ConfigurationExtension
    {
        public static WebApplicationBuilder AddAppConfiguration(this WebApplicationBuilder builder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .Build();

            builder.Services.AddSingleton(configuration);
            builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                            .AllowAnyMethod()
                                                                            .AllowAnyHeader()));
            return builder;
        }
    }
}
