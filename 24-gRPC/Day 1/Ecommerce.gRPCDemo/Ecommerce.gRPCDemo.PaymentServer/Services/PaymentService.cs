using Ecommerce.gRPCDemo.PaymentServer.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using SharedLibrary;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Ecommerce.gRPCDemo.PaymentServer.Protos.Payment;

namespace Ecommerce.gRPCDemo.PaymentServer.Services
{
    public class PaymentService : PaymentBase
    {
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(ILogger<PaymentService> logger)
        {
            _logger = logger;
        }

        public override Task<PaymentResponce> CheckBalance(OrderDetails request, ServerCallContext context)
        {
            // Check if the user has enough balance to make the payment
            var user = MockContext.Users.FirstOrDefault(x => x.Id == request.UserId);
            var item = MockContext.Items.FirstOrDefault(x => x.Id == request.ItemId);

            bool isSuccessful = user != null && user.Balance >= request.Price;

            // Create the payment response message
            var response = new PaymentResponce
            {
                IsSuccessful = isSuccessful,
                Stamp = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow)
            };

            if (isSuccessful && user is not null && item is not null)
            {
                // Deduct the amount from the user's balance
                user.Balance -= request.Price;
                _logger.LogInformation($"Deducted {request.Price} from user with ID {request.UserId} .. New Balance: {user.Balance} ");
            }

            return Task.FromResult(response);
        }
    }
}
