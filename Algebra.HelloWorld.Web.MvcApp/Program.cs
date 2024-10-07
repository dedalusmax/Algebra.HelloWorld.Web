using Algebra.HelloWorld.Data.Repositories;
using Algebra.HelloWorld.Domain.Interfaces;

namespace Algebra.HelloWorld.Web.MvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<IBookRepository, BookRepository>();

            var app = builder.Build();

            #region Testing env

            if (app.Environment.IsDevelopment()) {
                Console.WriteLine("Development environment");
            }
            else if (app.Environment.IsStaging())
            {
                Console.WriteLine("Staging environment");
            }
            else if (app.Environment.IsProduction())
            {
                Console.WriteLine("Production environment");
            }
            else if (app.Environment.IsEnvironment("Testing"))
            {
                Console.WriteLine("Testing environment");
            }
            else
            {
                Console.WriteLine("Custom environment: {0}", app.Environment.EnvironmentName);
            }

            #endregion

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
