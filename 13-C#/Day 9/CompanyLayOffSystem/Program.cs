namespace CompanyLayOffSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee()
            {
                EmployeeID = 200,
                BirthDate = new DateTime(1980, 2, 20),
                VacationStock = 20
            };

            Employee employee2 = new Employee()
            {
                EmployeeID = 201,
                BirthDate = new DateTime(1950, 5, 11),
                VacationStock = 25
            };

            Employee employee3 = new Employee()
            {
                EmployeeID = 202,
                BirthDate = new DateTime(1980, 3, 2),
                VacationStock = 30
            };

            SalesPerson sales1 = new SalesPerson()
            {
                EmployeeID = 400,
                BirthDate = new DateTime(1980, 3, 2),
                VacationStock = 30,
                AchievedTarget = 100
            };

            BoardMember bm1 = new BoardMember()
            {
                EmployeeID = 1000,
                BirthDate = new DateTime(1980, 3, 2),
                VacationStock = 30,
            };


            Department d1 = new Department() { DeptID = 1, DeptName = "SD" };
            Club c1 = new Club() { ClubID = 9090, ClubName = "AlexHeight-Club" };

            d1.AddStaff(employee1);
            d1.AddStaff(employee2);
            d1.AddStaff(employee3);

            c1.AddMember(employee1);
            c1.AddMember(employee2);
            c1.AddMember(employee3);

            d1.AddStaff(sales1);
            c1.AddMember(sales1);

            d1.AddStaff(bm1);
            c1.AddMember(bm1);

            //c1.Members.AddRange(d1.Staff); // we have to add them one by one to activate
            // the event subscription we created inside the Club class



            Console.WriteLine("Department members");

            Console.WriteLine(d1.DisplayDepartmentList);

            Console.WriteLine("Club members");
            Console.WriteLine(c1.DisplayClubList);

            /* Inside AddStaff we register each employee with the employeeLayOff event,
             By doing this we keep track with all of the employee's we have in the list
            */

            // both of these lines will invoke the event
            Console.WriteLine("\n=====================Vacation check ======================");

            employee1.RequestVacation(new DateTime(2022, 1, 2), new DateTime(2022, 3, 2));

            Console.WriteLine("\n =====================End of year check ======================");

            employee2.EndOfYearOperation();

            Console.WriteLine("===========================================\n");

            Console.WriteLine("Department members");
            Console.WriteLine(d1.DisplayDepartmentList);

            Console.WriteLine("Club members");
            Console.WriteLine(c1.DisplayClubList);

            

            

            Console.WriteLine("==================== Checking if sales request vacation =======================\n");


            sales1.RequestVacation(new DateTime(2022, 1, 2), new DateTime(2022, 3, 2));
            Console.WriteLine(" ===>  nothing happend");


            Console.WriteLine("\n =====================Check Sales target ======================");

            // less than goal.
            sales1.CheckTarget(50);

            Console.WriteLine("===========================================\n");


            Console.WriteLine("Department members");

            Console.WriteLine(d1.DisplayDepartmentList);
            Console.WriteLine("Club members");
            Console.WriteLine(c1.DisplayClubList);

            Console.WriteLine("=============== Board memeber ============================\n");


            bm1.Resign();

            Console.WriteLine("===========================================\n");


            Console.WriteLine("Department members");

            Console.WriteLine(d1.DisplayDepartmentList);
            Console.WriteLine("Club members");
            Console.WriteLine(c1.DisplayClubList);
            Console.ReadKey();
        }

      
    }
}
