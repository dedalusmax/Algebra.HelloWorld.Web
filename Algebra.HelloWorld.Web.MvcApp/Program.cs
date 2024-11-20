using Algebra.HelloWorld.Web.MvcApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Algebra.HelloWorld.Web.MvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<PetShopDbContext>(options =>
                options.UseSqlServer(connStr));

            builder.Services.AddTransient<DataSeed>();

            var app = builder.Build();

            // update all migrations to db
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<PetShopDbContext>();
            dbContext.Database.Migrate();

            //dbContext.Database.ExecuteSql("");

            var seeder = scope.ServiceProvider.GetRequiredService<DataSeed>();
            seeder.Run();

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
