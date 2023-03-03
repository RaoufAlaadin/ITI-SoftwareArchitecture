using CompanDBAPP.Context;
using CompanDBAPP.Entites;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace CompanDBAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

           using CompanyContext context = new CompanyContext(); 

            context.Database.EnsureCreated();

             /* USE THIS CAREFULLY*/

            /// This Line is instead of the command-Line (update-database)
            context.Database.Migrate();


            //context.Add(
            //    new Employee()
            //    {
            //        FName = "Raouf",
            //        MName = "A",
            //        LName = "Mazroaa",
            //        Salary = 2000
            //    });


            //var E = context.Employees.First(); 

            //E.Email = "Raoufalaa@gmail.com";
            //E.Phone= "0123456789";

            

            Console.WriteLine(
                $""" 
              Number of affected rows 
                {context.SaveChanges()} // Returns the number of affected rows. 
              """

                );

        }
    }
}



/*
 Commands 


PM> install-package Microsoft.EntityFrameWorkCore.sqlserver

install-package Microsoft.EntityFrameworkCore.Tools
install-package Microsoft.EntityFrameworkCore.Design


update-database  /// Will create a database called CompanyDB2023, which is stated in the Connection String. 

Add-Migration
remove-Migration

 */