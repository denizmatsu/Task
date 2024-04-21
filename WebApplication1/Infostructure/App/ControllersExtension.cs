namespace WebApplication1.Infostructure.App
{
    public static class ControllersExtension
    {
        public static WebApplication UseAppControllers(this WebApplication app)
        {
            // Add Controllers
            app.MapControllers();

            return app;
        }
    }
}
