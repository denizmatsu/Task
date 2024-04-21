namespace WebApplication1.Infostructure.App
{
    public static class AuthorizationExtension
    {
        public static WebApplication UseAppAuthorization(this WebApplication app)
        {
            app.UseAuthorization();

            return app;
        }
    }
}
