using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SinglaRDemoReaouf.Models;

namespace SinglaRDemoReaouf.Hubs
{
    
    public class ProductHub : Hub
    {
        private readonly MyDBContext context;

        public ProductHub(MyDBContext _context)
        {
            context = _context; 
        }
        #region Day1

        public async Task BuyRequest(int productId, int quantity)
        {
            var product = await context.Products.FindAsync(productId);
            if (product != null)
            {

                if (product.Quantity > 0)
                {
                    --product.Quantity;
                    context.SaveChanges();

                }
            }


            // This method activates "NotifyNewMessage" method for 
            // any browser connect currently to the same hub 
            await Clients.All.SendAsync("NotifyProductStock", productId, product?.Quantity);
        }

        public async Task AddComment(int productId, string username, string text)
        {
            // Save the comment to the database

            var product = context.Products.Include(c => c.Comments).FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                throw new ArgumentException($"Product with Id {productId} not found");
            }

            var comment = new Comment() { ProductId = productId, Text = text, Username = username };

            product.Comments?.Add(comment);
            await context.SaveChangesAsync();

            // Notify all clients of the new comment
            await Clients.All.SendAsync("NotifyNewComment", productId, username, text);
        }



        #endregion


        #region Day2

         // This is not needed here, we will apply it inside the action. 

        //public async Task AddNewProduct(Product product)
        //{
        //    await Clients.All.SendAsync("NotifyNewProduct", product);
        //} 
        #endregion
    }
}
