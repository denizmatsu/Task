using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication1.Infostructure.Services;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder
                .AddAppConfiguration()
                .AddAppDbContext()
                .AddAppControllers()
                .AddAppRepositories()
                ;
            builder.Services.AddHttpClient();
            builder.Services.AddControllersWithViews().AddFluentValidation();
            var app = builder.Build();
            builder.Configuration.AddEnvironmentVariables();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseCors("AllowAll");
            app.Run();
        }
    }
}
