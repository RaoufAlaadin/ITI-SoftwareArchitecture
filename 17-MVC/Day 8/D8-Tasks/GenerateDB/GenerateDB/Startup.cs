using GenerateDB.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GenerateDB
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        /* IWebHostEnviroment
         * => Helps us change the config based on the current Enviroment
         */
        public IWebHostEnvironment WebHost { get; }


        // request service of type Iconfiguration to be used here, 
        // create and inject this service here. !!! 
        public Startup(IConfiguration configuration, IWebHostEnvironment webHost)
        {


            Configuration = configuration;
            WebHost = webHost;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews();

            services.AddDbContext<pubsContext>(op =>
           op.UseSqlServer(Configuration.GetConnectionString("StudentCon"))
           
           );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

           

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                          name: "myOwnRoute",
                          pattern: "{Controller=Titles}/{Action=Index}/{id?}"
                      );
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
