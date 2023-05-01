using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class MockContext
    {
        public static List<Item> Items { get; set; } =
            new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "T-Shirt",
                    Quantity = 10,
                    Price = 200
                },
                new Item
                {
                    Id = 2,
                    Name = "Jeans",
                    Quantity = 5,
                    Price = 300
                },
                new Item
                {
                    Id = 3,
                    Name = "Sneakers",
                    Quantity = 8,
                    Price = 100
                },
                new Item
                {
                    Id = 4,
                    Name = "Smartphone",
                    Quantity = 3,
                    Price = 7000
                },
                new Item
                {
                    Id = 5,
                    Name = "Laptop",
                    Quantity = 2,
                    Price = 20000
                },
                new Item
                {
                    Id = 6,
                    Name = "Headphones",
                    Quantity = 7,
                    Price = 600
                }
            };

        public static List<User> Users { get; set; } =
            new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "John Doe",
                    Balance = 1000
                },
                new User
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Balance = 500
                },
                new User
                {
                    Id = 3,
                    Name = "Michael Johnson",
                    Balance = 750
                },
                new User
                {
                    Id = 4,
                    Name = "Emily Rodriguez",
                    Balance = 250
                },
                new User
                {
                    Id = 5,
                    Name = "David Kim",
                    Balance = 1500
                }
            };
    }
}
