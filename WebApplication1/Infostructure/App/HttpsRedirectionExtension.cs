namespace WebApplication1.Infostructure.App
{
    public static class HttpsRedirectionExtension
    {
        public static WebApplication UseAppHttpsRedirection(this WebApplication app)
        {
            // Add HttpsRedirection
            app.UseHttpsRedirection();

            return app;
        }
    }
}
