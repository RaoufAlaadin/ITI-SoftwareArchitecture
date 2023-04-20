using Microsoft.EntityFrameworkCore;

namespace SinglaRDemoReaouf.Models
{
    public static class DbSeeder
    {
        public static void Seed(MyDBContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
            {
                new Product { Name = "Apple MacBook Pro", Description = "A high-performance laptop with a sleek design", Price = 2000, Quantity = 10, ProductImage = "/Images/macbook.jpg" },
                new Product { Name = "Samsung Galaxy S21", Description = "A flagship smartphone with a stunning camera and powerful hardware", Price = 1000, Quantity = 20, ProductImage = "/Images/galaxys21.jpg" },
                new Product { Name = "Sony WH-1000XM4", Description = "Noise-cancelling headphones with excellent sound quality", Price = 350, Quantity = 30, ProductImage = "/Images/wh1000xm4.jpg" },
                new Product { Name = "Logitech MX Master 3", Description = "A high-end wireless mouse with advanced features", Price = 100, Quantity = 15, ProductImage = "/Images/mxmaster3.jpg" },
                new Product { Name = "Nintendo Switch", Description = "A hybrid gaming console with a unique design", Price = 300, Quantity = 5, ProductImage = "/Images/switch.jpg" },
            };
                context.Products.AddRange(products);
                context.SaveChanges();
            }

            if (!context.Comments.Any())
            {
                var comments = new List<Comment>
            {
                new Comment { Text = "Great laptop, very fast and easy to use", ProductId = 1, Username = "johndoe" },
                new Comment { Text = "The camera on this phone is amazing!", ProductId = 2, Username = "janedoe" },
                new Comment { Text = "These headphones are a game-changer for working from home", ProductId = 3, Username = "bobsmith" },
                new Comment { Text = "I love this mouse, it feels great in my hand", ProductId = 4, Username = "sarahjones" },
                new Comment { Text = "The Switch is so much fun, great for playing with friends", ProductId = 5, Username = "mikebrown" },
                new Comment { Text = "I had some issues with the laptop overheating, but otherwise it's great", ProductId = 1, Username = "janesmith" },
                new Comment { Text = "The battery life on this phone could be better", ProductId = 2, Username = "joebloggs" },
                new Comment { Text = "These headphones are a bit pricey but totally worth it", ProductId = 3, Username = "maryjane" },
                new Comment { Text = "The scroll wheel on this mouse is a bit too sensitive for my liking", ProductId = 4, Username = "davidlee" },
                new Comment { Text = "I wish there were more games available for the Switch", ProductId = 5, Username = "janedoe" },
            };
                context.Comments.AddRange(comments);
                context.SaveChanges();
            }
        }
    }
}
