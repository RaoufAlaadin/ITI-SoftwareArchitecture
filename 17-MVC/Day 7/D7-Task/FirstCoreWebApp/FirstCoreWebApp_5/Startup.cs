using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApp_5
{
    public class Startup
    {


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
       


        /* DI Container (Dependency injection container) 
        a Service provider, as it enclose all the services that I want to use.
        
         Add services to DI container => to be enablked for using inside web app by injection. 
        */
        public void ConfigureServices(IServiceCollection services)
        {
            /* The `services` input arg already holds 81 service that we might need 
             for web apps. 
            */

            //services.AddMvc(); // but not used as common now

            // Adding our own service here made the services go from 81 to 251 service.
            services.AddControllersWithViews(); // This one is better.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This won't matter for today.
            // Related to excpetion filtering. 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Middleware Error handling.
            }

            /* Notes: 
            1- Every Files has options. */


            /*
                        DefaultFilesOptions options = new DefaultFilesOptions();
                        *//* This clears all the default file and searches for Page1.html
                            If I add*//*
                        options.DefaultFileNames.Clear();
                        options.DefaultFileNames.Add("Page1.html"); */


            // Cannot be seen if it's outside the wwwroot, so if we set it outside 
            // it will run the index view 
            //app.UseDefaultFiles(options);  // use default.html -- index.html --- specific page 


            //app.UseDefaultFiles();

            //app.UseStaticFiles(); // Look inside wwwroot folder for static files.

            // Create routing table, save records for each route. 
            // Every route has an endpoint 
            app.UseRouting(); // Middleware Routing

            app.UseEndpoints(endpoints =>   // Add Entries to Routing Table.
            {
                // This routing is like MVC


                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Car}/{action=GetAllCars}/{id?}");

                endpoints.MapDefaultControllerRoute();


                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
