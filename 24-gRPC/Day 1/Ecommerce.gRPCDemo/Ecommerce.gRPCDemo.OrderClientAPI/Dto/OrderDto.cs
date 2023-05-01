namespace Ecommerce.gRPCDemo.OrderClientAPI.Dto
{
    public class OrderDto
    {
        public class InventoryOrderDetailsDto
        {
            public int ItemId { get; set; }
            public int Quantity { get; set; }
        }

        // Order details DTO for the Payment service
        public class PaymentOrderDetailsDto
        {
            public int ItemId { get; set; }
            public decimal Amount { get; set; }
        }

        // Combined order details DTO for the OrderClientAPI
        public class OrderDetailsDto
        {
            public int ItemId { get; set; }
            public int Quantity { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
