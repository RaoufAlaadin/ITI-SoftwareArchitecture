using CompanDBAPP.Configuration;
using CompanDBAPP.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanDBAPP.Context
{


        /* 4 Ways for Mapping  
         1- EF Convensions
         2- Data Annotation
         3- Fluent API 

         4- Configuration Class 
        Refactoring Fluent API into separate class per entity 
        
         ( The 4th method is just for organaizing, nothing new )
        We create a class for each Entity config, and just reference it in the 
        */
    public class CompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(
                "Data Source = .; Initial Catalog = Company2023DB;"
                    + "Integrated Security = true; Encrypt = false"
            );

        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Different style fro fluent API

            /// I create one per Entity

            /* New style for fluent API
             * 
             * 
             * 
             * modelBuilder.Entity<Client>(Entitybuilder =>
             {
                 Entitybuilder.Ignore(C => C.TimeStamp).HasKey(C => C.CID);

                 Entitybuilder.Property(C => C.FName).HasMaxLength(50);

                 /// And so on , this just compines everything here.
             });



             modelBuilder.Entity<Branch>(Entitybuilder =>
             {

                 Entitybuilder.Property(C => C.Name).HasMaxLength(20);
                 Entitybuilder.Property(C => C.City).HasMaxLength(10).IsUnicode(true);

                 /// And so on , this just compines everything here.
             });
            
             */

            // Normal Fluent API
            modelBuilder.Entity<Client>().Ignore(C => C.TimeStamp).HasKey(C => C.CID);

            modelBuilder.Entity<Client>().Property(C => C.FName).HasMaxLength(50);
            modelBuilder.Entity<Client>().Property(C => C.LName).HasMaxLength(50);

            modelBuilder
                .Entity<Client>()
                .Property(C => C.MName)
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired(false);

            modelBuilder
                .Entity<Client>()
                .Property(C => C.Deposite)
                .HasColumnType("money")
                .HasColumnName("OrderDeposite");


            /* 4th method activation*/
            //modelBuilder.ApplyConfiguration(new ClientEntityConfiguration());


            /// This creates a composite key. 
            modelBuilder
               .Entity<EmployeeClient>()
               .HasKey(EC => new { EC.EmployeeEID, EC.ClientCID });


            base.OnModelCreating(modelBuilder); // Why do we need this line ?
        }

        // but u have to add it to the original database in the first place.
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }

    }
}
