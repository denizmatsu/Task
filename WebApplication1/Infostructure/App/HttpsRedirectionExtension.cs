namespace WebApplication1.Infostructure.App
{
    public static class HttpsRedirectionExtension
    {
        public static WebApplication UseAppHttpsRedirection(this WebApplication app)
        {
            app.UseHttpsRedirection();

            return app;
        }
    }
}
