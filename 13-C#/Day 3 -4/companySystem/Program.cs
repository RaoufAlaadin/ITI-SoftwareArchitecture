namespace CompanySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ======SecurityLevels testing=======");

            Enums.SecurityLevels roleTest = Enums.SecurityLevels.securityOfficer;
            Console.WriteLine(roleTest);

            roleTest ^= Enums.SecurityLevels.Delete;
            Console.WriteLine(roleTest);

            Console.WriteLine(" ==========================");

            EmployeeSearch employeeArr;

            while (true)
            {
                int numberOfEmployees;
                do
                {
                    Console.WriteLine("Enter the number of employees:");

                    /* note: tryParse sets the out value to (0) on failure */

                    if (!int.TryParse(Console.ReadLine(), out numberOfEmployees))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                } while (numberOfEmployees == 0);

                Console.WriteLine(" ==========================");

                employeeArr = new EmployeeSearch(numberOfEmployees); // Array definition

                Utility.AddEmployee(employeeArr); // because I made it static, I can call it without creating an object. !!

                Console.WriteLine(" ==========================");
                Console.WriteLine("Press Q to view the array");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    Console.Clear(); // clears the window screen

                    //Employee.DisplayAllEmployees(employeeArr.Employee);


                    Console.WriteLine("==========testing indexers===============");

                    Console.WriteLine("national ID search ");

                    employeeArr[200].getEmployeeData();

                    Console.WriteLine("name  search ");
                    employeeArr["ahmed"].getEmployeeData();

                    //Console.WriteLine(employeeArr.Employee[0].MyHireDate);

                    Console.WriteLine("date search ");

                    HiringDate h1 = new HiringDate();
                    h1.MyHireDate = "20/2/2020";

                    employeeArr[h1].getEmployeeData();

                    break; // breaks the while loop
                }
            }

            Console.ReadKey(); // prevents the console from exit(0) until I press any key.
        }
    }
}
