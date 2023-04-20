using Microsoft.EntityFrameworkCore;

namespace SinglaRDemoReaouf.Models
{
    public class MyDBContext:DbContext
    {

        public MyDBContext(DbContextOptions<MyDBContext> options) :base(options) { }    


        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
