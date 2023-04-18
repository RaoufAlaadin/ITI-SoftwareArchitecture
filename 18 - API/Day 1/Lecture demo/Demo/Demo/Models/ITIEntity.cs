using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Demo.Models
{
    public class ITIEntity:IdentityDbContext<ApplicationUser>
    {
        // ctor => wizard -- manual I think
        public ITIEntity() { }

        // ctor => for injection
        public ITIEntity(DbContextOptions options): base(options)
        {
        } 

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> employees { get; set; }


        /*      
         * This is bad, we use Ioc container instead. 
         *      
         *      
         *      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyDatabase;");
        }
        */


    }
}
