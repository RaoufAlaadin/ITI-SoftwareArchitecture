using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MainDBContext: DbContext
    {
        public MainDBContext():base("myConRaouf")
        {
        }  

        public DbSet<Client> Clients { get; set; }


    }
}