using Microsoft.EntityFrameworkCore;
using SinglaRDemoReaouf.Hubs;
using SinglaRDemoReaouf.Models;

namespace SinglaRDemoReaouf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Database


            var connectionString = builder.Configuration.GetConnectionString("myConn") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<MyDBContext>(options =>
            {
                //options.UseLazyLoadingProxies().UseSqlServer(connectionString);
                options.UseSqlServer(connectionString);

            });
            #endregion



            #region HubService

            builder.Services.AddSignalR();

            #endregion

            //After build, the services become readonly.
            var app = builder.Build();

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

            #region Hub Middleware

            // Hub Middleware, Add the service.
            app.MapHub<ChatHub>("/MyChatHub");
            //app.MapHub<>("");  //foreach hub we have.
            //Mapping hub 


            app.MapHub<ProductHub>("/ProductHub");
            #endregion


            #region DataSeeder

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MyDBContext>();
                DbSeeder.Seed(context);
            }
            #endregion

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}