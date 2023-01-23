using System.Collections.Generic;

namespace Task1_arrayOfInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(value: "Hello, World!");

            /*            Your task will be to write a program 
             *            
             find the longest distance Two equal cells. 
            In this example.The distance is measured by the number
            Of cells- for example, the distance between the first and the fourth cell is
            2(cell 2 and cell 3).
            In the example above, the longest distance is between the first 7 and the
            10th 7, with a distance of 8 cells, i.e.the number of cells between the 1st
            And the 10th 7s.
            Note:
            -Array values will be taken from the user
            -If you have input like 1111111 then the distance is the number of
            Cells between the first and the last cell.*/





            //Console.WriteLine("Enter the size of the array.");
            //int arrSize =int.Parse(Console.ReadLine());
            //Console.WriteLine("================== Enter Elements ======================");

            int[] arr = new int[12] { 7, 0, 0, 0, 5, 6, 7, 5, 0, 7, 5, 3 };
            //int[] arr = new int[12] { 1,1,1,1,1,1,1,1,1,1,1,1 };



            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine($"element[{i+1}] = ");
            //    arr[i] = int.Parse(Console.ReadLine());
            //}

            Console.WriteLine("================== Array Output ======================");

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("================== Largest Distance between equal elements ======================");

            int elementValue = 0;
            int maxDistance = 0;  
            
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = i+1; j  < arr.Length; j ++)
                {
                    if (arr[i] == arr[j] && maxDistance < (j - i - 1))
                    {
                        maxDistance = j - i - 1;
                        elementValue = arr[j];
                    }
                }
            }

            Console.WriteLine($"ElementValue is : {elementValue}");
            Console.WriteLine( $"Largest Distance between equals is: {maxDistance}");

        }
    }
}