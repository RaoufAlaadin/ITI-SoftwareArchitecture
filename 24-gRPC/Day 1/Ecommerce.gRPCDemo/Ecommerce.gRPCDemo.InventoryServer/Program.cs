using Ecommerce.gRPCDemo.InventoryServer;
using Ecommerce.gRPCDemo.InventoryServer.Services;

namespace Ecommerce.gRPCDemo.InventoryServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();

            #region Needed for testing 

            builder.Services.AddGrpcReflection(); 

            #endregion


            var app = builder.Build();

            #region For mapping the IncomingRequest to the current service. 

            app.MapGrpcService<InventoryService>(); 

            #endregion


            // Configure the HTTP request pipeline.
            //app.MapGrpcService<GreeterService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}