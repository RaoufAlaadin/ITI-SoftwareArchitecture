using Microsoft.EntityFrameworkCore;
using NorthWindConsoleAPP.Context;
using NorthWindConsoleAPP.Entites;

namespace NorthWindConsoleAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using NorthwindContext context = new();

            #region If we wrote the query ( Impilict loading)

            //// returns products `out of stocks`
            //var Result = (from P in context.Products

            //              // This retrives the Category table through the navigational property
            //              // This way we don't need to add them in the `Select statement`
            //              .Include(P => P.Category)
            //              .Include(P => P.Supplier)


            //              where P.UnitsInStock == 0
            //              select P

            //              /* // Anonymous type // has it's own ToString.
            //               // The following will create a `join` in sql profiler.
            //               select new {P.ProductName,P.Category.CategoryName}
            //              */
            //              /* // Here we basically reach out to other tables, using the `navigational properties`
            //               // That we have in Code.
            //               // This results in a join query later on in sql server.
            //               select new {P.ProductName, P.Category.CategoryName, P.Supplier.CompanyName }
            //              */
            //              ).ToList();

            //foreach (var item in Result)
            //{
            //    /* The effect of `Lazy Loading` using `Virtual` keyword appears here,
            //     * Because if we didn't mention the `Navigational property` in the `select query`
            //     * Then it won't be loaded with the object !!!!!
            //     * and so The current statement will give you  ==> (NULL)
            //        */
            //    Console.WriteLine($" Product {item.ProductName}, Category {item.Category?.CategoryName ?? "NA"}");
            //}
            #endregion




            #region If we  DIDN'T write the query ( Exciplict loading)

            //// returns products `out of stocks`
            //var Result = (from P in context.Products


            //              where P.UnitsInStock == 0
            //              select P


            //              ).ToList();

            //foreach (var item in Result)
            //{
            //    // gets called once, for later foreach iteration it will be there.
            //    if (item.Category == null)
            // Downside is => multiple trips to DB for checks.
            // if we are retriving a collection, then put `.Collection` instead of the  `.Reference`
            //        context.Entry(item).Reference(P => P.Category).Load();

            //    Console.WriteLine($" Product {item.ProductName}, Category {item.Category.CategoryName }");
            //}
            #endregion


            #region Explicit loading BUT without extra code.

            /* Steps
             * 1-
             * install-package Microsoft.EntityFrameworkCore.Proxies
             *
               2-
               Then we add one more line inside the modelBuilder. */
            // returns products `out of stocks`
            var Result = (from P in context.Products where P.UnitsInStock == 0 select P).ToList();

            foreach (var item in Result)
            {
                Console.WriteLine(
                    $" Product {item.ProductName}, Category {item.Category.CategoryName}"
                );
            }
            #endregion
        }
    }
}
