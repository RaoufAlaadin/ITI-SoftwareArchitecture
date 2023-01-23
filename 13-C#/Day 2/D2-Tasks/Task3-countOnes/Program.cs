using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Task3_countOnes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*            How can you count the occurrence of 1 from 1 to 99,999,999(1 short
             of 100 million) and total up how many 1s were there.
             (Convert Numbers to String in Case one and use String Functions to
             Count 1s,
             Use Only Mathematical Functions and Numeric values in case 2 and see
             the difference in performance)
            Is There Any Other Way to Do it in Approximately 1 Second or less

            */

            /* Method 1 */

            Console.WriteLine("using string");


            Stopwatch stopwatch = new();
            stopwatch.Start();

            int count = 0;

            for (int i = 0; i < Math.Pow(10, 8); i++)
            {
                string str = i.ToString();

                if (str.IndexOf('1') != -1)
                {
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (str[j] == '1')
                            count++;
                    }

                }
            }

            stopwatch.Stop();
            Console.WriteLine($"number of One's ===>    {count}");
            Console.WriteLine($"time in msec ====>   {stopwatch.ElapsedMilliseconds / 1000}");
            Console.WriteLine("======================================");

            /* Method 2 */


            Stopwatch stopwatch1 = new();
            stopwatch1.Start();

            int count1 = 0;


            Console.WriteLine("using mod and divide by 10");

            for (int i = 0; i < Math.Pow(10, 8); i++)
            {

                int temp = i;

                while (temp != 0)
                {
                    if ((temp % 10) == 1)
                        count1++;

                    temp /= 10;
                }

            }


            stopwatch1.Stop();
            Console.WriteLine($"number of One's ===>    {count1}");
            Console.WriteLine($"time in msec ====>   {stopwatch1.ElapsedMilliseconds/1000}");
            Console.WriteLine("======================================");






            /* Method 3 */

            Console.WriteLine("using math equation");

            Stopwatch stopwatch2 = new();
            stopwatch2.Start();

            int count2 = 0;

            //n times 10 ^ (n - 1)
            int n = 8; // the power no. for base of 10 

            count2 = (int)(n * Math.Pow(10, n - 1));


            stopwatch2.Stop();
            Console.WriteLine($"number of One's ===>    {count2}");
            Console.WriteLine($"time in msec ====>   {stopwatch2.ElapsedMilliseconds / 1000}");
            Console.WriteLine("======================================");


        }
    }
}