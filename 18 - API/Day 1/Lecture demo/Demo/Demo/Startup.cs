using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Demo.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ITIEntity>(
                options =>
                    options.UseSqlServer(
                        "Data Source=.; Initial Catalog=WebAPIMonofia; Integrated Security= True"
                    )
            );

            services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ITIEntity>();

            // [Authooriz] used JWT toekn in checking Authentication, while his default is cookies
            // that's why it was returning not found

            services
                .AddAuthentication(options =>
                {
                    // The following accpets token only.


                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    // prompt the user the autheticate themselves when trying to access something
                    // that they do not have authorization to.

                    // That's `challenging` the system acess.
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    // This validate the token

                    // save the token after authentication.
                    options.SaveToken = true;

                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JWT:ValidIssure"],
                        // there is also audcienceS , for declaring many consumers
                        // Which is usually the case with APIs
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:ValidAudiance"],
                        // We already know the Hashing Algorithm used by looking at the token,
                        // That's why we only need the `key`
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])
                        )
                    };
                });

            // -------------------------------------------

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
            });

            /// Swagger authorization UI


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "JWTToken_Auth_API", Version = "v2" });
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description =
                            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                    }
                );
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    }
                );
            });

            ///// adding CORS configs

            services.AddCors(CorsOptions =>
            {
                CorsOptions.AddPolicy(
                    "myPolicy",
                    CorsPolicyBuilder =>
                    {
                        //CorsPolicyBuilder.WithOrigins("http://127.0.0.1:5500");
                        CorsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo v1"));
            }

            app.UseRouting();

            //////////
            app.UseStaticFiles();
            app.UseCors("myPolicy");

            // Check JWT token not the cookie
            // We have to configure it in above.
            app.UseAuthentication();

            //////////

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
