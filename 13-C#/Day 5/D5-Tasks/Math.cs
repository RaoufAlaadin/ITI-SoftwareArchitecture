using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D5_Tasks
{
    static class Math
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static bool Divide(int x, int y, out int result)
        {
            try
            {
                //  this line can result in division by 0 
                result = x / y;
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }
}
