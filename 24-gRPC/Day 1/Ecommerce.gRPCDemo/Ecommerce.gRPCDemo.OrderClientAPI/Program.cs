using Ecommerce.gRPCDemo.InventoryServer.Protos;
using Ecommerce.gRPCDemo.PaymentServer.Protos;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.gRPCDemo.OrderClientAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            #region Creating a channel and a client (VeryImportant) !!


            builder.Services.AddSingleton(services =>
            {
                var grpcChannel = GrpcChannel.ForAddress(builder.Configuration.GetValue<string>("InventoryService:GrpcUrl"));
                return new Inventory.InventoryClient(grpcChannel);
            });

            builder.Services.AddSingleton(services =>
            {
                var grpcChannel = GrpcChannel.ForAddress(builder.Configuration.GetValue<string>("PaymentService:GrpcUrl"));
                return new Payment.PaymentClient(grpcChannel);
            });



            // Add a singleton GrpcChannel instance to the DI container
            //builder.Services.AddSingleton(services =>
            //{
            //    return GrpcChannel.ForAddress(builder.Configuration.GetValue<string>("InventoryService:GrpcUrl"));
            //});

            //// Add the Inventory.InventoryClient as a singleton service
            //builder.Services.AddSingleton(services =>
            //{
            //    var channel = services.GetRequiredService<GrpcChannel>();
            //    return new Inventory.InventoryClient(channel);
            //});

            //// Add the Payment.PaymentClient as a singleton service
            //builder.Services.AddSingleton(services =>
            //{
            //    var channel = services.GetRequiredService<GrpcChannel>();
            //    return new Payment.PaymentClient(channel);
            //});


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


            app.MapControllers();

            app.Run();
        }
    }
}