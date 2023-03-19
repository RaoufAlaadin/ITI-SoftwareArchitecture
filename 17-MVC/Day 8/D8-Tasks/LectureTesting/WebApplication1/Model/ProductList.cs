using System.Collections.Generic;

namespace WebApplication1.Model
{
    public class ProductList
    {
        public static List<Product> Products = new List<Product>() {


                new Product() { Id = 1, Name = "Red T-Shirt", Price = 25.99m },
                new Product() { Id = 2, Name = "Blue Jeans", Price = 49.99m },
                new Product() { Id = 3, Name = "Black Sneakers", Price = 69.99m },
                new Product() { Id = 4, Name = "White Hoodie", Price = 39.99m },
                new Product() { Id = 5, Name = "Green Jacket", Price = 79.99m }


        }; 

        
    }
}
