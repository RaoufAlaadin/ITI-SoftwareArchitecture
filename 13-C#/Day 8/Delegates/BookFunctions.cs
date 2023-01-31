using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
           return $"\t{B.Title}";
        }
        public static string GetAuthors(Book B)
        {
            return $"\t{String.Join(",",B.Authors)}";
        }
        public static string GetPrice(Book B)
        {
            return $"\t{B.Price:C}";
        }
    }
}
