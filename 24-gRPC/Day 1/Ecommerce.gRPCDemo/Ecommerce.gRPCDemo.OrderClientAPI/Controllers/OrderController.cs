using Ecommerce.gRPCDemo.InventoryServer.Protos;
using Ecommerce.gRPCDemo.PaymentServer.Protos;


using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce.gRPCDemo.OrderClientAPI.Dto.OrderDto;

namespace Ecommerce.gRPCDemo.OrderClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly Inventory.InventoryClient _inventoryClient;
        private readonly Payment.PaymentClient _paymentClient;

        public OrderController(
            ILogger<OrderController> logger,
            Inventory.InventoryClient inventoryClient,
            Payment.PaymentClient paymentClient
        )
        {
            _logger = logger;
            _inventoryClient = inventoryClient;
            _paymentClient = paymentClient;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] InventoryServer.Protos.OrderDetails orderDetails)
        {
            try
            {
                // There must be a better way.
                var paymentRequest = new PaymentServer.Protos.OrderDetails()
                {
                    UserId = orderDetails.UserId,   
                    Price = orderDetails.Price,
                    ItemId = orderDetails.ItemId,
                    ItemName = orderDetails.ItemName,
                    Quantity = orderDetails.Quantity
                    
                };
               
                var inventoryResponse = await _inventoryClient.CheckInventoryAsync(orderDetails);
                if (!inventoryResponse.InStock)
                {
                    _logger.LogInformation($"Item with ID {orderDetails.ItemId} is out of stock.");
                    return BadRequest($"Item with ID {orderDetails.ItemId} is out of stock.");
                }

                var paymentResponse = await _paymentClient.CheckBalanceAsync(paymentRequest);
                if (!paymentResponse.IsSuccessful)
                {
                    _logger.LogInformation($"Payment for item with ID {paymentRequest.ItemId} failed.");
                    var IncreaseStock = await _inventoryClient.IncreaseStockAsync(orderDetails);
                    return BadRequest("Insuffisent balance");
                }

                _logger.LogInformation($"Item with ID {paymentRequest.ItemId} is in stock and payment successful.");
                return Ok("Order has been made");
            }
            catch (RpcException ex)
            {
                _logger.LogError(
                    ex,
                    $"gRPC error while creating order for item with ID {orderDetails.ItemId}"
                );
                return StatusCode((int)ex.StatusCode);
            }
        }
    }
}
