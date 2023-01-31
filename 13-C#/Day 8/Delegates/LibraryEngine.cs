using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    /* a.User Defined Delegate Datatype*/

    public delegate string userDelegate (Book B) ;

    /*b.BCL Delegates*/



    public class LibraryEngine
    {
            /* must be declared inside the class unlike the user-defined delegate*/
        /* Check the syntax*/
        public Func <Book, string>? bclDelegate ;

       
        /* 1- user defined */
        /*public static void ProcessBooks(List<Book> bList
        , userDelegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }*/

        /* 2- BCL  */

        public static void ProcessBooks(List<Book> bList
       , Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}
