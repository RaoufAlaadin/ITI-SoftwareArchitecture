using DepartementTask.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.DAL.Data.Context
{
    public class DepartementContext:DbContext
    {
        public DbSet<Departement> departements => Set<Departement>();
        public DbSet<Tickets> tickets => Set<Tickets>();
        public DbSet<Developer> developers => Set<Developer>();

        public DepartementContext(DbContextOptions<DepartementContext> options)
            :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Departement>().HasData(
                new Departement { Id = 1, Name = "Sales" },
                new Departement { Id = 2, Name = "Marketing" },
                new Departement { Id = 3, Name = "Finance" },
                new Departement { Id = 4, Name = "HR" },
                new Departement { Id = 5, Name = "IT" }
            );
            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, Name = "John Doe" },
                new Developer { Id = 2, Name = "Jane Smith" },
                new Developer { Id = 3, Name = "Bob Johnson" },
                new Developer { Id = 4, Name = "Emily Davis" },
                new Developer { Id = 5, Name = "David Lee" }

            );
            modelBuilder.Entity<Tickets>().HasData(
                new Tickets { Id = 1, Name = "Ticket 1", Description = "This is ticket 1", DepartementId = 1 },
                new Tickets { Id = 2, Name = "Ticket 2", Description = "This is ticket 2", DepartementId = 2 },
                new Tickets { Id = 3, Name = "Ticket 3", Description = "This is ticket 3", DepartementId = 3 },
                new Tickets { Id = 4, Name = "Ticket 4", Description = "This is ticket 4", DepartementId = 4 },
                new Tickets { Id = 5, Name = "Ticket 5", Description = "This is ticket 5", DepartementId = 5 }

            );
        }
    }
}
