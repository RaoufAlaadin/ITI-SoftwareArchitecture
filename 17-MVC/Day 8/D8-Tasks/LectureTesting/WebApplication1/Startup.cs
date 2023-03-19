using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1
{
    public class Startup
    {
        /* Iconfiguration allows us to read config data from different places,
         Ex:  appsettings.json, environment variables, command-line arguments 

        Use case => Getting the ConnectionString from the appsettings.json 
        */
        public IConfiguration Configuration { get;}

        /* IWebHostEnviroment
         * => Helps us change the config based on the current Enviroment
         */
        public IWebHostEnvironment WebHost { get;} 


        // request service of type Iconfiguration to be used here, 
        // create and inject this service here. !!! 
        public Startup(IConfiguration configuration, IWebHostEnvironment webHost)
        {
            // 1- Created by the framework,
            // 2- Will be contained automatically in Services at run time.
            // 3- ... now we inject... to use.

            Configuration = configuration;
            WebHost = webHost;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddMvc();
            services.AddControllersWithViews(); // this one is better

            /* Getting the Connection string, we have 3 methods : 
             *
             * 1- 
               2-from the appsettings.json 
               3- 
            */

            /*  services.AddDbContext<ProductDBContext>(op =>
              //op.UseSqlServer("Data Source = .; Initial Catalog =ProductCoreDB; Integrated Security=True")
              //op.UseSqlServer(Configuration["ConnectionStrings:myConn"]) 
              op.UseSqlServer(Configuration.GetConnectionString("myConn"))
              );*/

            services.AddDbContext<StudentCourseDBContext>(op =>
            op.UseSqlServer(Configuration.GetConnectionString("StudentCon")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /* Based on the current Enviroment, We will pick up the needed resources
                different lanuchSettings enviroment variable, different elements.  
            
            Default if we remove the .json is : Production stage 
             */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Styles Path from local 
                // ConnectionString to Test DB 
            }
            else if ( env.IsProduction())
            {
                app.UseExceptionHandler();
                //Styles path from CDN 
                // ConnectionString to final DB
            }
            else if (env.IsEnvironment("StagingAfterFirstchange"))
            {

            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                           name: "myOwnRoute",
                           pattern: "{Controller=Students}/{Action=Index}/{id?}"
                       );


                // the default is "home => index" but it's set automatically 

                //endpoints.MapDefaultControllerRoute(); 


                #region Endpoint that prints the appsetting.json key or enviroment key

                /* endpoints.MapGet("/", async context =>
                 {
                         *//* We have 2 keys, one in the "General" which is production
                          and one in the appsettings.development.json
                         our current Enviroment is : Development

                     NOTE: if we change the .json to Production, do not run in `debug mode`
                             or you will get an `Error` due to the confusion ,
                             --- you do not debug a program you already released---
                         *//*

                     await context.Response.WriteAsync("Hello World!" + "\n" + Configuration["myKey"]);
                 });*/ 
                #endregion


            });
        }
    }
}
