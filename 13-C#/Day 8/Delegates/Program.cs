using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Delegates
{
    internal class Program
    {
        #region CodeMonkey test delegates
        /*user-defined delegate signtures
         usually you will be using the ones declared built-in the system itself.


        public delegate void testDelegate();

    public delegate bool boolDelegatte(int i);*/
        #endregion

    static void Main(string[] args)
        {
            /*      1. Try Every Point Covered in the Lecture
            2. Considering the Code Below , Write Down the Body of all Listed
            Methods and Properties ,

            you need to Define fPtr as the following cases:

            a. User Defined Delegate Datatype

            b. BCL Delegates

            c. Anonymous Method (GetISBN)

            d. Lambda Expression (GetPublicationDate)
            
             
             */


            List<Book> bList = new List<Book>();

            Book book1 = new Book("ISBN-0001", "To Kill a Mockingbird", new string[] { "Harper Lee" }, new DateTime(1960, 7, 11), 10.99m);
            Book book2 = new Book("ISBN-0002", "The Great Gatsby", new string[] { "F. Scott Fitzgerald" }, new DateTime(1925, 4, 10), 12.99m);
            Book book3 = new Book("ISBN-0003", "Pride and Prejudice", new string[] { "Jane Austen" }, new DateTime(1813, 1, 28), 8.99m);
            Book book4 = new Book("ISBN-0004", "1984", new string[] { "George Orwell" }, new DateTime(1949, 6, 8), 11.99m);
            Book book5 = new Book("ISBN-0005", "The Catcher in the Rye", new string[] { "J.D. Salinger" }, new DateTime(1951, 7, 16), 9.99m);

            bList.Add(book1);
            bList.Add(book2);
            bList.Add(book3);
            bList.Add(book4);
            bList.Add(book5);


            Console.WriteLine(" \n ====== book Titles ========\n");
            LibraryEngine.ProcessBooks(bList, BookFunctions.GetTitle);

            Console.WriteLine("\n====== Author names  ========\n");


            LibraryEngine.ProcessBooks(bList, BookFunctions.GetAuthors);

            Console.WriteLine("\n====== Books prices   ========\n");

            LibraryEngine.ProcessBooks(bList, BookFunctions.GetPrice);

            Console.WriteLine("\n====== Books ISBN   ========\n");

                /* You have to include the keyword delegate when creating an anonymus function. !!!! */

            LibraryEngine.ProcessBooks(bList, delegate (Book B) { return $"\t{B.ISBN}";});

            Console.WriteLine("\n====== Books Publication Date    ========\n");

                /* Testing Lamda Expression */
            LibraryEngine.ProcessBooks(bList, (Book B) => { return $"\t{B.PublicationDate}"; });










            #region CodeMonkey Notes 
            /*testDelegate fptr;
            boolDelegatte boolPtr;

        notes: When assigning a function to a delegate reference fptr ..this is what actually happens in the background

                              fptr = new testDelegate(testfun) ==> we made a new instance from the delegate type we made.

                              and by default we have to pass in the function we want to point at..which is ===> testfun


              fptr = testfun;

            fptr();

            fptr = testfun2;

            fptr();

            // multi-Cast ===> triggering multiple functions at the same time.

            Console.WriteLine("\n ======= Mutli-Cast =========== \n");
            fptr = testfun;
            fptr += testfun2;

            fptr();

            Console.WriteLine("\n ======= Delegates with paramters =========== \n");

            boolPtr = testBool;

            bool x = boolPtr(3);

            Console.WriteLine(x);

            Console.WriteLine("\n ======= Annoynmous methods =========== \n");

            fptr = delegate ()
            {
                Console.WriteLine("We are Anonmyous ");
            };

            fptr();

            Console.WriteLine("\n ======= Lamda Expression methods =========== \n");

            note that this means you won't have a unique reference to a function as soon as
               you move your fptr out of it... you won't have anything to reference it back

                  like in the case of the Multi - cast => you won't be able to add or remove methods to the single pointer.




              fptr = () =>
              {
                  Console.WriteLine("We are Lamda annon ");
              };

            fptr();

            Console.WriteLine("\n ======= Generic Built-in Delegates =========== \n");

            Console.WriteLine("\n ======= Action =========== \n");


            Actions takes to 16 input parameters and for each of them it returns void.


       Action testAction;

            Example
              Action<int, float> testAction2;

            testAction2 = (int i, float f) =>
            {
                Console.WriteLine("daaamn");
            };

            testAction2(5, 3);

            Console.WriteLine("\n ======= FunC =========== \n");

            //have as many input paramters but the last parameter is always a return parameter
            //      if you have only parameter then it's considered that return parameter !! 


              Func<int, float> testFunc;*/

            #endregion

            #region Lecture Notes
/*
            1 - calling the method using:
             *
             *fptr(input parameter) is unsafe , as fptr might be null!!
             *
             *fptr?.invoke("hi") ?? 0 ====> this is the type safe version
             *
             *invoke() was already being called implicitly, but writing it explicitly
             *allows us to ensure the type safe. 
             *
             *
             *2 - our main function body(boolDelegate fptr, --- )  and when calling the function we pass in the function name
             * we want to use.
             *
             *so it will look like this at the end ==> fptr = computeFn
             *
             *
             *3 - writing the following            if (CompFuncPtr?.Invoke(-----) == true)
                *
                *we added the true because if comFuncPtr was null , then everything on the left side is null
                * and null does not evaluate to anything inside an if statement
                *
                *so we added the == true to compare it to the null we got, which will resullt to(false)
                *                              as they are not equal.
   
                *
                *ubt if CompFuncPtr was not Null ===> the invoking will return a number ,
             *and any number evalutes to true....so   true == true... is true
             *
             *and we go inside the if () body.
             *
             *
*/
                #endregion




            Console.ReadKey();
        }


        #region CodeMonkey test functions
       /* public static void testfun()
        {
            Console.WriteLine("test fun got called");
        }

        public static void testfun2()
        {
            Console.WriteLine("oh hello there x2 ");
        }

        public static bool testBool(int i)
        {
            return i < 5;
        }*/
        #endregion

    }
}
