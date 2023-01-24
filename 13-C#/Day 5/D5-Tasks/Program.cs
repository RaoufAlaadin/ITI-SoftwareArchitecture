namespace D5_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n========  1- override ToString() ================\n");
            
            Point3D P = new Point3D(10, 10, 10);
            Console.WriteLine(P.ToString());

            
            Console.WriteLine("\n======== 2- Casting (string) by doing operatorOverloading ================\n");


            string str = (string)P;

            Console.WriteLine(str);

            Console.WriteLine("\n======== 3- reading userInput  ================\n");
            // 3- reading userInput 

            Point3D P1, P2;
            P1 = Point3D.ReadPoint();
            P2 = Point3D.ReadPoint();

            Console.WriteLine(P1.ToString());
            Console.WriteLine(P2.ToString());

            Console.WriteLine("\n ======== 4- P1 == P2 , we have to overload it================ \n");

            
            Console.WriteLine($" P1 = P2 result is ==> {P1 == P2}");

            Console.WriteLine("\n ======== overloading Equals================ \n");

          
            Console.WriteLine($" P1.Equals(P2) result is ==> {P1.Equals(P2)}");


            Console.WriteLine("\n ======== 7-8 - static Math Class (for utility purpose) ================ \n");

            
            int a = 5;
            int b = 2;
            int result;

            result = Math.Add(a, b);
            Console.WriteLine($"Addition: {a} + {b} = {result}");

            result = Math.Subtract(a, b);
            Console.WriteLine($"Subtraction: {a} - {b} = {result}");

            result = Math.Multiply(a, b);
            Console.WriteLine($"Multiplication: {a} * {b} = {result}");

            /* if no division by 0, it will return true*/
            if (Math.Divide(a, b, out result))
                Console.WriteLine($"Divsion: {a} / {b} = {result}");
            else
                Console.WriteLine("Error:Division by 0 ");

            Console.WriteLine("\n ======== 9- NIC Singleton Class ================ \n");

            NIC O1 = NIC.SingleTonObj;

            Console.WriteLine( " Manufacture: " + NIC.SingleTonObj.Manufacture + 
                                ", MAC Address: " + NIC.SingleTonObj.MacAddress +
                                 ", Type: " + NIC.SingleTonObj.NicType);



            Console.WriteLine("\n ======== 10- Duration Test Cases  ================ \n");

            Duration d1 = new Duration(1, 10, 15);
            Console.WriteLine(d1.ToString()); 

            Duration d2 = new Duration(3600);
            Console.WriteLine(d2.ToString()); 

            Duration d3 = new Duration(7800);
            Console.WriteLine(d3.ToString()); 

            Duration d4 = new Duration(666);
            Console.WriteLine(d4.ToString()); 

            Duration d5 = d1 + d2;
            Console.WriteLine(d5.ToString()); 

            Duration d6 = d1 + 7800;
            Console.WriteLine(d6.ToString());

            Duration d7 = 666 + d3;
            Console.WriteLine(d7.ToString()); 

            d7++;
            Console.WriteLine(d7.ToString()); 

            --d3;
            Console.WriteLine(d3.ToString());

            

            if (d1 > d2)
                Console.WriteLine("d1 is greater than d2");
            else
                Console.WriteLine("d1 is not greater than d2");

            if (d1 <= d2)
                Console.WriteLine("d1 is less than or equal to d2");
            else
                Console.WriteLine("d1 is not less than or equal to d2");

            if (d1)
                Console.WriteLine("d1 is non-zero");
            else
                Console.WriteLine("d1 is zero");

            DateTime date = (DateTime)d1;
            Console.WriteLine(date);

        }
    }
}