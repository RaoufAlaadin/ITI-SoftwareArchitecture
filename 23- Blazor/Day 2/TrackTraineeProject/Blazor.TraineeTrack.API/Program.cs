
using Blazor.TraineeTrack.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.TraineeTrack.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            #region Database

            var connectionString = builder.Configuration.GetConnectionString("MyConn") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<MyTraineeTrackDBContext>(options =>
                    options.UseSqlServer(connectionString)
                    );

            builder.Services.AddCors(options =>
            options.AddPolicy("MyPolicy", PolicyOptions => 
                PolicyOptions.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            ));

            #endregion
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MyTraineeTrackDBContext>();
                DbSeeder.Seed(context);
            }


            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}