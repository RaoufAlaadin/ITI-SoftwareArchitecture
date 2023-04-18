
//using DepartementTask.BL.Managers.DeveloperManager;
using DepartementTask.BL.Managers.DoctorManager;
using DepartementTask.BL.Managers.TicketManager;
using DepartementTask.BL.Managers.TicketsManager.TicketManager;
using DepartementTask.DAL.Data.Context;
using DepartementTask.DAL.Repos.DepartementRepo;
//using DepartementTask.DAL.Repos.DeveloperRepo;
using DepartementTask.DAL.Repos.TicketRepo;
using Microsoft.EntityFrameworkCore;


namespace DepartementTaskApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region Database

            var connectionString = builder.Configuration.GetConnectionString("DepartementCon");
            builder.Services.AddDbContext<DepartementContext>(options
                => options.UseSqlServer(connectionString));

            #endregion

            #region Repos
            builder.Services.AddScoped<IDepartementsRepo, DepartementsRepo>();
            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
            //builder.Services.AddScoped<IDevelopersRepo, DevelopersRepo>();
            #endregion

            #region Managers
            builder.Services.AddScoped<IDepartementManager, DepartementManager>();
            builder.Services.AddScoped<ITicketsManager, TicketsManager>();
            //builder.Services.AddScoped<IDevelopersManager, DevelopersManager>();
            #endregion

            #region AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}