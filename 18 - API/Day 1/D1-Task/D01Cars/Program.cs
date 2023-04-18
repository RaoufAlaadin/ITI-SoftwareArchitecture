
using D01Cars.Models;
using System.Diagnostics.Metrics;

namespace D01Cars
{
    public class Program
    {
        //public static int counter = 0;
        
        public static void Main(string[] args)
        {
            car.counter = 0; 
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

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

            // Middelware
            //app.Use(async (contex, next) =>
            //{
            //    Console.WriteLine("Before Calling Next Middelware");
            //    //Before Request
            //    await next(contex);
            //    car.counter++;
            //    //After Response
           
            //});

            app.MapControllers();

            app.Run();
        }
    }
}