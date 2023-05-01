using Ecommerce.gRPCDemo.InventoryServer.Protos;
using Grpc.Core;
using SharedLibrary;
using static Ecommerce.gRPCDemo.InventoryServer.Protos.Inventory;

namespace Ecommerce.gRPCDemo.InventoryServer.Services
{
    public class InventoryService : InventoryBase
    {
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(ILogger<InventoryService> logger)
        {

            _logger = logger;
        }


        public override Task<InventoryResponce> CheckInventory(OrderDetails request, ServerCallContext context)
        {
            // Check if the requested item is in stock
            var item = MockContext.Items.FirstOrDefault(x => x.Id == request.ItemId);
            bool isInStock = item != null && item.Quantity >= request.Quantity;

            if (isInStock && item is not null)
            {
            _logger.LogInformation($"The item  {item.Name} is in stock with quntatity of {item.Quantity} ");
            }

            // Create the inventory response message
            var response = new InventoryResponce
            {
                InStock = isInStock ,
                Stamp = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow)
            };

            if (isInStock && item is not null)
            {
                // Update the quantity of the item in the list
                item.Quantity -= request.Quantity;
                _logger.LogInformation($"Decreased the stock of {item.Name} by {request.Quantity} .. New Stock: {item.Quantity} ");
            }

            return Task.FromResult(response);
        }



        public override Task<IncreaseStockResponse> IncreaseStock(OrderDetails request, ServerCallContext context)
        {
            // Find the item in the inventory
            var item = MockContext.Items.FirstOrDefault(x => x.Id == request.ItemId);

            // If the item is not found, return an error
            if (item is null)
            {
                var error = new Status(StatusCode.NotFound, $"Item with ID {request.ItemId} not found.");
                throw new RpcException(error);
            }

            // Increase the stock of the item
            item.Quantity += request.Quantity;

            _logger.LogInformation($"Increased the stock of {item.Name} by {request.Quantity} .. New Stock: {item.Quantity}");

            // Create the response message
            var response = new IncreaseStockResponse
            {
                Success = true
            };

            return Task.FromResult(response);
        }
    }
}
