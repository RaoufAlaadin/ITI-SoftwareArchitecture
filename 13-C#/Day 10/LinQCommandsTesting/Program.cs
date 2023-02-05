using LinQCommandsTesting;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using static LinQCommandsTesting.ListGenerators;

namespace LinQCommandsTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /***** Resources *******
             
              1- Best youtube playlist for studying LinQ
             https://www.youtube.com/playlist?list=PL4cyC4G0M1RTqz_MOJJxarYmX_qAYChyB

              2-aslo there is john skeet's blog

            https://codeblog.jonskeet.uk/category/edulinq/

             */

            #region LINQ 1- Restriction Operators
            ////Use ListGenerators.cs & Customers.xml


            ////1.Find all products that are out of stock.

            //Console.WriteLine(" ====== Find all products that are out of stock. ===");

            //var Result = ProductList.Where(P => P.UnitsInStock == 0);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"ProductName: {item.ProductName} === > Stock:{item.UnitsInStock}");
            //}



            ////2.Find all products that are in stock and cost more than 3.00 per unit.

            //Result = ProductList.Where(P => (P.UnitsInStock != 0) && (P.UnitPrice > 3));

            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"ProductName: {item.ProductName} === > Stock:{item.UnitsInStock} Price ===> {item.UnitPrice}");
            //}



            ////3.Returns digits whose name is shorter than their value.


            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
            //"nine" };


            //var arrResult = Arr.Where((e, index) => (index > e.Length));

            //foreach (var item in arrResult)
            //{
            //    Console.WriteLine($"allowed number: {item} ");
            //}


            ////Result = from P in ProductList
            ////         where P.UnitsInStock == 0
            ////         select P;

            ///////V2.0 Indexed where , only using Fluent Syntax
            ///////i : element index in input Sequence
            ////Result = ProductList.Where((P, index) => (index < 10) && (P.UnitsInStock == 0));

            #endregion










            #region LINQ 2- Element Operators


            ////            Use ListGenerators.cs & Customers.xml


            ////1.Get first Product out of Stock

            //// it returns only one element
            //var Result = ProductList.FirstOrDefault(P => (P.UnitsInStock == 0));
            //Console.WriteLine($"ProductName: {Result?.ProductName} === > Stock:{Result?.UnitsInStock} Price ===> {Result.UnitPrice}");



            ////2.Return the first product whose Price > 1000, unless there is no match, in which case null
            ////is returned.

            ///* FirstOrDefault will only prevent the error in it's line and assign 0 to Result
            //    but if we try to access Elements in that 0, We will still get an Error in the
            //    Console.WriteLine() ==> so we have to use the null operator.
            // */

            //Result = ProductList.FirstOrDefault(P => (P.UnitPrice > 1000));
            //Console.WriteLine($"ProductName: {Result?.ProductName?? "N/A"} === > Stock:{Result?.UnitsInStock ?? 0} Price ===> {Result?.UnitPrice ?? 0}");



            ////3.Retrieve the second number greater than 5


            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            ///*
            // * We first filter out the array from anything below 5, even 5 itself
            //   then we get the ElementAt the second index ==> 0,{1},2,3

            // */
            //var arrResult = Arr.Where(x => x > 5).ElementAt(1);

            //Console.WriteLine(arrResult);

            #endregion


            ////////////////////////////////////////////////

            #region LINQ 3- Set Operators


            ////Use ListGenerators.cs & Customers.xml


            ////1.Find the unique Category names from Product List

            ///*  https://www.youtube.com/watch?v=VqlAKwJuJlE&list=PL4cyC4G0M1RTqz_MOJJxarYmX_qAYChyB&index=26&ab_channel=Kudvenkat.Arabic
            // *
            // *  Long method => create an override for the equals and gethashCode manually
            // *  in ProductList or new Class
            //    short method => we create an anonymous object inside the select statement
            //     which will implicitly override the equals and hash code and return only the
            //    columns we requested.

            //But !! calling the 2 columns together will require us to also use
            // */

            //var Result = ProductList.Select(p => new { p.Category }).Distinct();


            ////var Result = ProductList.Select(p => new { p.ProductName, p.Category }).Distinct();

            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"CategoryName: {item.Category}");
            //    //Console.WriteLine($"ProductName: {item.ProductName} ============CategoryName: {item.Category}");


            //}

            ////2.Produce a Sequence containing the unique first letter from both product and customer
            ////names

            //    /* first letters used in both, but without duplicates.
            //        We use Union ==> makes more sense for our case
            //    or  concat + distinct()
            //     */

            //var Result1 = ProductList.Select(p => p.ProductName[0]).Union(CustomerList.Select(c => c.CompanyName[0]));
            //foreach (var item in Result1)
            //{
            //    Console.WriteLine($"Sequence : {item}");


            //}

            //Console.WriteLine("======================");

            ////
            ////.3.Create one sequence that contains the common first letter from both product and
            ////customer names.

            //// common ==> that appeared in both names ... so intersect.

            //var Result2 = ProductList.Select(p => p.ProductName[0]).Intersect(CustomerList.Select(c => c.CompanyName[0]));
            //foreach (var item in Result2)
            //{
            //    Console.WriteLine($"Sequence : {item}");


            //}

            //Console.WriteLine("======================");



            ////4.Create one sequence that contains the first letters of product names that are not also
            ////first letters of customer names.

            //// not also first letters ===> so the letter that appeared on one side and didn't
            //// appear on the other.... so we use Except.

            //var Result3 = ProductList.Select(p => p.ProductName[0]).Except(CustomerList.Select(c => c.CompanyName[0]));
            //foreach (var item in Result3)
            //{
            //    Console.WriteLine($"Sequence : {item}");


            //}

            //Console.WriteLine("======================");


            ////5.Create one sequence that contains the last Three Characters in each names of all
            ////customers and products, including any duplicates

            //    /* We want duplicates... so we use concat without distinct() or anything extra */

            //var Result4 = ProductList.Select(p => p.ProductName.Substring(p.ProductName.Length - 3)).Concat(CustomerList.Select(c => c.CompanyName.Substring(c.CompanyName.Length - 3)));
            //foreach (var item in Result4)
            //{
            //    Console.WriteLine($"Sequence : {item}");


            //}

            //Console.WriteLine("======================");

            #endregion



            #region LINQ 4- Aggregate Operators


            //    //1.Uses Count to get the number of odd numbers in the array
            //    int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //    var Result = Arr.Count(x=> x % 2 != 0);

            //    Console.WriteLine(Result);

            ////            Use ListGenerators.cs & Customers.xml

            ////2.Return a list of customers and how many orders each has.

            ////https://www.youtube.com/watch?v=dLQc4KQy-A0&list=PL4cyC4G0M1RTqz_MOJJxarYmX_qAYChyB&index=18&ab_channel=Kudvenkat.Arabic

            //    //var Result1 = CustomerList.GroupBy(c =>  c.CustomerID);


            //    //foreach (var item in Result1)
            //    //{
            //    //    Console.WriteLine($"Customer: {item.Key} ===> no. Of orders ={item.Count()} ");
            //    //}

            //    foreach (var item in CustomerList)
            //    {
            //        Console.WriteLine($"{item.CustomerID},{item.Orders.Length}");
            //    }
            //    //3.Return a list of categories and how many products each has

            //    var Result2 = ProductList.GroupBy(p => p.Category);


            //    foreach (var item in Result2)
            //    {
            //        Console.WriteLine($"Category: {item.Key} ===> no. Of Products ={item.Count()} ");
            //    }


            //    //4.Get the total of the numbers in an array.
            //    int[] Arr1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //    // he means the sum

            //    var resultArr = Arr1.Sum();

            //    Console.WriteLine(resultArr);


            //    //5.Get the total number of characters of all words in dictionary_english.txt(Read
            //    // dictionary_english.txt into Array of String First).

            //    string[] Dictionary_English;
            //    try
            //    {
            //        Dictionary_English = System.IO.File.ReadAllLines(@"dictionary_english.txt");
            //    }
            //    catch (System.IO.FileNotFoundException)
            //    {
            //        Console.WriteLine("File not found");
            //        return;
            //    }

            //    //foreach (string line in Dictionary_English)
            //    //{
            //    //    Console.WriteLine(line);
            //    //}

            //    // the lamda will specify each element, get it's number of characters , and add that to the sum.
            //    var totalChar = Dictionary_English.Sum(x => x.Length);

            //    Console.WriteLine($"Number of charachters in the dictionary ==> {totalChar}");

            //    //Use ListGenerators.cs & Customers.xml
            //    //6.Get the total units in stock for each product category.


            //        /* Basically what happens here is:
            //            we create groups of products that has the same category name,
            //            the we manipulate those groups using the select statement instead
            //        of doing it in the foreach later on.
            //        we assign the g.key to Category variable.. easier naming to be called at printing
            //        the second column will have the sum of units in that group

            //        chaining the select into the group by had the same effect of giving us only one item
            //        in the foreach ... so here g is one group .. so we call the sum method
            //        our source is (g) which is one group
            //        and our selector is the following lamda that specifies.. for each row in the g
            //        return unitInStock and add it to the sum !!

            //        at last.. this will return 2 columns to Result3..
            //        Category name and the TotalUnitsInStock infront of it.


            //            */
            //    var Result3 = ProductList
            //                  .GroupBy(p => p.Category)
            //                  .Select( g => new {Category = g.Key, TotalUnitsInStock = g.Sum(s => s.UnitsInStock)});

            //    foreach (var item in Result3)
            //    {
            //        Console.WriteLine($" CategoryName: {item.Category} ===== > TotalUnitsInStock: {item.TotalUnitsInStock}");
            //    }

            //    //7.Get the length of the shortest word in dictionary_english.txt(Read dictionary_english.txt into
            //    //Array of String First).

            //    var shortestWord = Dictionary_English.Min(x => x.Length);

            //    Console.WriteLine(shortestWord);


            //    //Use ListGenerators.cs & Customers.xml
            //    //8.Get the cheapest price among each category's products

            //    /* Same as the above query, just needed to use Min and look at prices.*/

            //    var Result4 = ProductList
            //                 .GroupBy(p => p.Category)
            //                 .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });

            //    foreach (var item in Result4)
            //    {
            //        Console.WriteLine($" CategoryName: {item.Category} ===== > CheapestPrice: {item.CheapestPrice}");
            //    }


            //    //9. Get the products with the cheapest price in each category (Use Let)

            //    var Result5 = from product in ProductList
            //                  group product by product.Category
            //                  into productGroup //  (INTO) so we are dealing with each group separatly.
            //                                    // anything above productGroup cannot be Accesed later on.

            //                  let cheapestPrice = productGroup.Min(p => p.UnitPrice)
            //                  // (let) allows us to store our complex stuff into variables
            //                  // it allows for better readability.
            //                  select new { Category = productGroup.Key, CheapestPrice = cheapestPrice };

            //    Console.WriteLine("================ using let =========");
            //    foreach (var item in Result5)
            //    {
            //        Console.WriteLine($" CategoryName: {item.Category} ===== > CheapestPrice: {item.CheapestPrice}");
            //    }

            //    //10.Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt
            //    //into Array of String First).
            //    //Use ListGenerators.cs & Customers.xml


            //    var longestWord = Dictionary_English.Max(x => x.Length);

            //    Console.WriteLine(longestWord);

            //    //11.Get the most expensive price among each category's products.

            //    var Result6 = from product in ProductList
            //                  group product by product.Category
            //                  into productGroup //  (INTO) so we are dealing with each group separatly.
            //                                    // anything above productGroup cannot be Accesed later on.

            //                  let highestprice = productGroup.Max(p => p.UnitPrice)
            //                  // (let) allows us to store our complex stuff into variables
            //                  // it allows for better readability.
            //                  select new { Category = productGroup.Key, HighestPrice = highestprice };

            //    Console.WriteLine("================ using let =========");
            //    foreach (var item in Result6)
            //    {
            //        Console.WriteLine($" CategoryName: {item.Category} ===== > HighestPrice: {item.HighestPrice}");
            //    }

            //    //12.Get the products with the most expensive price in each category.


            //        /* the oldest trick in the book, order by descendikng then take the first row*/
            //    var result7 = ProductList
            //        .GroupBy(p => p.Category)
            //        .Select(g => new
            //        {
            //            Category = g.Key,
            //            MostExpensiveProduct = g.OrderByDescending(p => p.UnitPrice).First()
            //        });

            //    foreach (var item in result7)
            //    {
            //        Console.WriteLine($"Category: {item.Category}");
            //        Console.WriteLine($"Most Expensive Product: {item.MostExpensiveProduct.ProductName}");
            //        Console.WriteLine($"Price: {item.MostExpensiveProduct.UnitPrice}");
            //        Console.WriteLine();
            //    }

            //    /* could have used the following
            //     *
            //    var result = ProductList.GroupBy(p => p.Category)
            //        .Select(g => new {
            //            Category = g.Key,
            //            MostExpensiveProduct = g.Where(p => p.UnitPrice == g.Max(p => p.UnitPrice))
            //                                 .FirstOrDefault().ProductName,
            //            Price = g.Max(p => p.UnitPrice)
            //        });


            //    basically .FirstOrDefault().ProductName helped us get only the top value from the
            //    list of prices per group i guess.

            //     */

            //    //13.Get the average length of the words in dictionary_english.txt(Read
            //    //dictionary_english.txt into Array of String First).


            //    var avgLength = Dictionary_English.Average(x => x.Length);

            //    Console.WriteLine(avgLength);
            //    //14.Get the average price of each category's products.

            //    var Result8 = ProductList
            //                .GroupBy(p => p.Category)
            //                .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) });

            //    foreach (var item in Result8)
            //    {
            //        Console.WriteLine($" CategoryName: {item.Category} ===== > AveragePrice: {item.AveragePrice}");
            //    }

            #endregion





            #region LINQ 5- Ordering Operators

            ////Use ListGenerators.cs & Customers.xml
            ////1.Sort a list of products by name

            //var result = ProductList.OrderBy(p => p.ProductName);

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}");
            //}

            //Console.WriteLine();
            ////2.Uses a custom comparer to do a case-insensitive sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            ////            Use ListGenerators.cs & Customers.xml

            ///* Very important !!!! */
            //var sortedWords = Arr.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);

            //foreach (var word in sortedWords)
            //{
            //    Console.WriteLine(word);
            //}
            //Console.WriteLine();

            ////3.Sort a list of products by units in stock from highest to lowest.
            //var result1 = ProductList.OrderByDescending(p => p.UnitsInStock);

            //foreach (var item in result1)
            //{
            //    Console.WriteLine(
            //        $"Product Name: {item.ProductName} \t UnitsInStock: {item.UnitsInStock}"
            //    );
            //}

            //Console.WriteLine();
            ////4.Sort a list of digits, first by length of their name, and then alphabetically by the name
            ////itself.

            //string[] Arr1 =
            //{
            //    "zero",
            //    "one",
            //    "two",
            //    "three",
            //    "four",
            //    "five",
            //    "six",
            //    "seven",
            //    "eight",
            //    "nine"
            //};

            ///*  We use ThenBy() to give the Orderby other parameters to order on
            //    after the first option is done.
            //*/

            ///* Element length , then alphapitically means the value of the element itself.
            //*/
            //var sortedDigits = Arr1.OrderBy(x => x.Length).ThenBy(x => x);

            //foreach (var digit in sortedDigits)
            //{
            //    Console.WriteLine(digit);
            //}
            //Console.WriteLine();

            ////5.Sort first by word length and then by a case-insensitive sort of the words in an array.
            //string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            ////  Use ListGenerators.cs & Customers.xml

            //var sortedWords1 = words
            //    .OrderBy(w => w.Length)
            //    .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            //foreach (var word in sortedWords1)
            //{
            //    Console.WriteLine(word);
            //}

            //Console.WriteLine();

            ////6.Sort a list of products, first by category, and then by unit price, from highest to lowest.


            //var result2 = ProductList.OrderBy(p => p.Category).ThenByDescending(u => u.UnitPrice);

            //foreach (var item in result2)
            //{
            //    Console.WriteLine(
            //        $"Product Category: {item.Category} \t UnitPrice: {item.UnitPrice} "
            //    );
            //}
            //Console.WriteLine();

            ////7.Sort first by word length and then by a case-insensitive descending sort of the words in
            ////an array.

            //string[] Arr2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var sortedWords2 = Arr2.OrderByDescending(w => w.Length)
            //    .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);

            //foreach (var word in sortedWords2)
            //{
            //    Console.WriteLine(word);
            //}
            //Console.WriteLine();

            ////8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the
            ////order in the original array.


            //string[] Arr3 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
            //"nine" };

            //var result4 = Arr3.Where(s => s[1] == 'i').Reverse().ToList();

            //foreach (var item in result4)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion






            #region LINQ 6- Partitioning Operators
            ////            Use ListGenerators.cs & Customers.xml

            ////1.Get the first 3 orders from customers in Washington

            ////foreach (var item in CustomerList.Where(x=> x.Country == "USA" && x.Region == "WA"))
            ////{
            ////    Console.WriteLine(item);
            ////}

            //var Result = CustomerList
            //    .Where(l => l.Region == "WA")
            //    .Select(x => new { CustomerName = x.CompanyName, order = x.Orders.Take(3) });

            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"CompanyName: {item.CustomerName} ");
            //    foreach (var singleOrder in item.order)
            //    {
            //        Console.WriteLine(
            //            $" \t \t Order ID : {singleOrder.OrderID}, Order ID : {singleOrder.OrderDate},"
            //        );
            //    }
            //}
            //Console.WriteLine();

            ///*      You can Also use this.. it uses SelectMany which flattens any
            // *      collection inside of a collection
            // *      so we will be able to get all the values of the first 3 orders in only line
            // *      but the query below need some adjustment as .Select() will have only
            //        data about the order, So we don't have access to customer name*/
            ///*
            // *
            // * var result = CustomerList.Where(c => c.Region == "WA")
            //              .SelectMany(c => c.Orders.Take(3))
            //              .Select(o => new { CustomerName = o.Customer.CompanyName, OrderID = o.OrderID, OrderDate = o.OrderDate });

            // foreach (var item in result)
            // {
            //     Console.WriteLine($"Customer Name: {item.CustomerName} | Order ID: {item.OrderID} | Order Date: {item.OrderDate}");
            // }

            // */



            ////2.Get all but the first 2 orders from customers in Washington.

            //var Result1 = CustomerList
            //    .Where(l => l.Region == "WA")
            //    .Select(x => new { CustomerName = x.CompanyName, order = x.Orders.Skip(2) });

            //foreach (var item in Result1)
            //{
            //    Console.WriteLine($"CompanyName: {item.CustomerName} ");
            //    foreach (var singleOrder in item.order)
            //    {
            //        Console.WriteLine(
            //            $" \t \t Order ID : {singleOrder.OrderID}, Order ID : {singleOrder.OrderDate},"
            //        );
            //    }
            //}

            ////3.Return elements starting from the beginning of the array until a number is hit that is
            ////less than its position in the array.

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //// this works... but it's so bad !!!

            ////var resultNumbers = numbers.TakeWhile(x => x > numbers.ToList().IndexOf(x));

            ////here is the better version.
            //// using the .TakeWhile overload that gives the current index.
            //// doesn't matter if u name it index or Ahmed.. what matters is the order.

            //var resultNumbers = numbers
            //    .TakeWhile((x, index) => x > index)
            //    // using this select we are able to print out the index. !!!
            //    // but this index we printed is for the new anonymous object, not the original array
            //    .Select((num, index) => new { Value = num, Index = index });

            //foreach (var item in resultNumbers)
            //{
            //    Console.WriteLine($" num : {item.Value} \t index:{item.Index}");
            //}

            //Console.WriteLine();

            //// 4.Get the elements of the array starting from the first element divisible by 3.
            //int[] numbers1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var resultNumbers1 = numbers1
            //    .SkipWhile((x, index) => x % 3 != 0)
            //    // using this select we are able to print out the index. !!!
            //    // but this index we printed is for the new anonymous object, not the original array
            //    .Select((num, index) => new { Value = num, Index = index });

            //foreach (var item in resultNumbers1)
            //{
            //    Console.WriteLine($" num : {item.Value} \t index:{item.Index}");
            //}

            //Console.WriteLine();
            ////5.Get the elements of the array starting from the first element less than its position.
            //int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var resultNumbers2 = numbers2
            //    .SkipWhile((x, index) => x > index)
            //    // using this select we are able to print out the index. !!!
            //    // but this index we printed is for the new anonymous object, not the original array
            //    .Select((num, index) => new { Value = num, Index = index });

            //foreach (var item in resultNumbers2)
            //{
            //    Console.WriteLine($" num : {item.Value} \t index:{item.Index}");
            //}

            #endregion
            //
            //




            #region LINQ 7- Projection Operators


            ///* Select vs SelectMany
            //        https://www.youtube.com/watch?v=Ar2P6ToW5tc&list=PL4cyC4G0M1RTqz_MOJJxarYmX_qAYChyB&index=9&ab_channel=Kudvenkat.Arabic
            //*/
            ////Use ListGenerators.cs & Customers.xml

            ////1.Return a sequence of just the names of a list of products.

            //var Result = ProductList.Select(x => x.ProductName);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine();
            ////2.Produce a sequence of the uppercase and lowercase versions of each word in the
            ////original array(Anonymous Types).

            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //var resultWords = words.Select(
            //    x => new { UpperCase = x.ToUpper(), lowerCase = x.ToLower() }
            //);

            //foreach (var item in resultWords)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();
            ////            Use ListGenerators.cs & Customers.xml
            ////3.Produce a sequence containing some properties of Products, including UnitPrice which
            ////is renamed to Price in the resulting type.

            //var Result1 = ProductList.Select(
            //    x => new { Name = x.ProductName, Price = x.UnitPrice }
            //);

            //foreach (var item in Result1)
            //{
            //    Console.WriteLine(item);
            //}

            ////4.Determine if the value of ints in an array match their position in the array.
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var postionArr = Arr.Select(
            //    (x, index) => new { Value = x, InPlace = x == index ? "True" : "False" }
            //);

            //foreach (var item in postionArr)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine();

            //// Test Cases ===>
            ////            Result
            ////            Number: In - place ?
            ////            5 : False
            ////4: False
            ////1: False
            ////3: True
            ////9: False
            ////8: False
            ////6: True
            ////7: True
            ////2: False
            ////0: False



            ////5.Returns all pairs of numbers from both arrays such that the number from numbersA is
            ////less than the number from numbersB.

            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var result =
            //    from a in numbersA
            //    join b in numbersB on true equals true
            //    // on true equals true will join everything,
            //    // the filtering is done by the where
            //    where a < b
            //    select new { a, b };

            //foreach (var pair in result)
            //{
            //    Console.WriteLine($"{pair.a} is less than {pair.b}");
            //}

            ///* solving it with the fluent syntax will look ugly and un-readable basically.

            //   var result = numbersA.SelectMany(a => numbersB.Where(b => a < b), (a, b) => new { a, b });

            //    foreach (var pair in result)
            //    {
            //    Console.WriteLine($"{pair.a} is less than {pair.b}");
            //    }
            //*/

            ////            Result
            ////            Pairs where a<b:
            ////0 is less than 1
            ////0 is less than 3
            ////0 is less than 5
            ////0 is less than 7
            ////0 is less than 8
            ////2 is less than 3
            ////2 is less than 5
            ////2 is less than 7
            ////2 is less than 8
            ////4 is less than 5
            ////4 is less than 7
            ////4 is less than 8
            ////5 is less than 7
            ////5 is less than 8
            ////6 is less than 7
            ////6 is less than 8
            ////Use ListGenerators.cs & Customers.xml


            ////6.Select all orders where the order total is less than 500.00.


            ///*
            //    https://www.youtube.com/watch?v=hzfgXXns5hQ&list=PL4cyC4G0M1RTqz_MOJJxarYmX_qAYChyB&index=8&ab_channel=Kudvenkat.Arabic
            // */

            ////var Result2 = CustomerList.SelectMany(
            ////    x => x.Orders.Where(o => o.Total < 500),
            ////    (customer, order) =>
            ////        new
            ////        {
            ////            customerName = customer.CompanyName,
            ////            OrderID = order.OrderID,
            ////            OrderTotal = order.Total
            ////        }
            ////);

            //// let's try to write it in SQL like syntax

            ///* Important !!!
            // *
            // * SQL like syntax is waaaaaaaaaaaay easier when dealing with
            // lists inside another List

            // SelectMany needs some time to get used to and also
            // it's not that readable at the end.

            // */

            //var Result2 = from customer in CustomerList
            //              from Order in customer.Orders
            //              where Order.Total < 500
            //              select new
            //              {
            //                  CustomerID = customer.CustomerID,
            //                  orderID = Order.OrderID,
            //                  orderTotal = Order.Total
            //              };


            //foreach (var item in Result2)
            //{

            //    Console.WriteLine(item);
            //}

            ////7.Select all orders where the order was made in 1998 or later.

            //var Result3 = from customer in CustomerList
            //              from Order in customer.Orders
            //              // we had to get the year from the DateTime data type
            //              // gives us a quick and an accurate comparison.
            //              where Order.OrderDate.Year >= 1998
            //              select new
            //              {
            //                  CustomerID = customer.CustomerID,
            //                  orderID = Order.OrderID,
            //                  OrderDate = Order.OrderDate
            //              };


            //foreach (var item in Result3)
            //{

            //    Console.WriteLine(item);
            //}



            #endregion





            #region LINQ 8- Quantifiers
            //1.Determine if any of the words in dictionary_english.txt(Read dictionary_english.txt into
            //Array of String First)
            //contain the substring 'ei'.

            /*
             * contains checks patterns automatically,
             so we don't need to do any extra work
            */

            /*
             *
            string[] dictionary = File.ReadAllLines("dictionary_english.txt");


            var wordsWithEi = dictionary.Where(w => w.Contains("ei"));

            foreach (var word in wordsWithEi)
            {
                Console.WriteLine(word);
            }

            */
            //Use ListGenerators.cs & Customers.xml



            //2.Return a grouped a list of products only for categories that have at least one product
            //that is out of stock.

            // how to output data from group ... groupby... grouping
            // these are key words for when I want to search this document.

            var Result = ProductList
                .GroupBy(x => x.Category)
                .Where(x => x.Any(s => s.UnitsInStock == 0));

            foreach (var item in Result)
            {
                Console.WriteLine();
                Console.WriteLine($"Category Name : {item.Key}");
                Console.WriteLine();

                foreach (var x in item)
                {
                    Console.WriteLine($"Product Name : {x.ProductName}");
                }
            }
            Console.WriteLine("=======================================");

            //3.Return a grouped a list of products only for categories that have all of their products in
            //stock.



            var Result1 = ProductList
                .GroupBy(x => x.Category)
                .Where(x => x.All(s => s.UnitsInStock != 0));

            foreach (var item in Result1)
            {
                Console.WriteLine();
                Console.WriteLine($"Category Name : {item.Key}");
                Console.WriteLine();

                foreach (var x in item)
                {
                    Console.WriteLine($"Product Name : {x.ProductName}");
                }
            }

            #endregion




            #region LINQ 9- Grouping Operators

            //1.Use group by to partition a list of numbers by their remainder when divided by 5


            //Output:
            //Numbers with a remainder of 0 when divided by 5:
            //0 5
            //10
            //Numbers with a remainder of 1 when divided by 5:
            //1 6
            //11
            //Numbers with a remainder of 2 when divided by 5:
            //7 2
            //12
            //Numbers with a remainder of 3 when divided by 5:
            //3 8
            //13
            //Numbers with a remainder of 4 when divided by 5:
            //4 9
            //14

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            var result = numbers
                .GroupBy(n => n % 5)
                .Select(g => new { Remainder = g.Key, Numbers = g.ToList() });

            foreach (var item in result)
            {
                Console.WriteLine(
                    $"Numbers with a remainder of {item.Remainder} when divided by 5:"
                );
                foreach (var number in item.Numbers)
                {
                    Console.WriteLine(number);
                }
            }

            //2.Uses group by to partition a list of words by their first letter.
            //Use dictionary_english.txt for Input

            string[] words = File.ReadAllLines("dictionary_english.txt");

            var wordGroups =
                from word in words
                group word by word[0] into firstLetterGroup
                orderby firstLetterGroup.Key
                select firstLetterGroup;

            foreach (var group in wordGroups)
            {
                Console.WriteLine($"Words that start with the letter '{group.Key}':");

                /*I used take(10) on the group to shorten the list
                  This allows for quick check for the code's effect
                without waiting for the whole dictionary to finish
                 */

                foreach (var word in group.Take(10))
                {
                    Console.WriteLine("\t" + word);
                }
            }

            //3.Consider this Array as an Input
            string[] Arr = { "from ", " salt", " earn ", " last ", " near", "form" };

            //Use Group By with a custom comparer that matches words that are consists of the same
            //Characters Together
            //Result...
            //from
            //form
            //...
            //salt
            //last

            // Method-1
            var result1 = Arr.GroupBy(s => s.Trim(), new AnagramEqualityComparer());
            foreach (var group in result1)
            {
                Console.WriteLine("Words that are anagrams of each other:");
                foreach (var word in group)
                {
                    Console.WriteLine(word);
                }
            }

            // Method-2 - Anonymous Objects

            Console.WriteLine("==================");
            string[] Arr1 = { "from ", " salt", " earn ", " last ", " near", "form" };

            /*Basically What happens here is that groupBy
              will group similar keys together.
              
              1- so we pass in a word to the group. then we sort the word ascending
              from a to z
              2- then concatenat will join the characters to form a word again

              --note-- this will not affect the original word

             3- we do the same to all the words, then group by group strings
              that were found similar
             4- then we print the pairs using the select statement
                 by passing an Anonymous object to it.
             
             */
            var result2 = Arr1.GroupBy(word => string.Concat(word.OrderBy(c => c)))
                .Select(
                    group =>
                        new
                        {
                            Key = group.Key,
                            /* ToList() is just in case we have more than word that is a match*/
                            Words = group.ToList()
                        }
                );

            foreach (var item in result2)
            {
                Console.WriteLine(item.Key + ": " + string.Join(", ", item.Words));
            }

            #endregion
        }
    }

    class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Concat(x.OrderBy(c => c)).Equals(string.Concat(y.OrderBy(c => c)));
        }

        public int GetHashCode(string obj)
        {
            return string.Concat(obj.OrderBy(c => c)).GetHashCode();
        }
    }
}
