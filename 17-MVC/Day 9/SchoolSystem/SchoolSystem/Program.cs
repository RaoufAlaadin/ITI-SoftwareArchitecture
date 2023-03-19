using Microsoft.EntityFrameworkCore;
using SchoolSystem.RepoServices;
using System;
using Microsoft.AspNetCore.Identity;
using SchoolSystem.Data;
using SchoolSystem.Areas.Identity.Data;

namespace SchoolSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            #region ConnectionString and AddDBcontext service injection 

            var connectionString =
                builder.Configuration.GetConnectionString("myConn") ??
                throw new InvalidOperationException("Connection string 'MyDBContext' not found.");
            /* The problem here that the scafolding didn't create addDBContext by default
             for the identity,
            also we can use the same connection string, as we want to have the identity tables
            on the same database. 
            */
            
            builder.Services.AddDbContext<SchoolSystemContext>
                (options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<SchoolSystemUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SchoolSystemContext>();





            #endregion


            #region InjectingOurOwnServices

            /* Anyone who request service of type "I...." , 
             create and Inject obj of type "....." with scoped lifetiem. 
            */

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            builder.Services.AddScoped<ITraineeCourseRepository, TraineeCourseRepository>();


            #endregion



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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Trainees}/{action=Index}/{id?}");

            // mapRazorPage is important for allowing the acess to reg and login pages
            // when creating the identity. 
            app.MapRazorPages();
            app.Run();
        }
    }
}