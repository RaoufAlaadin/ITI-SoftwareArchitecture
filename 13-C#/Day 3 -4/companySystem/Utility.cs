using System;
using System.Text.RegularExpressions;
using static CompanySystem.Enums;

namespace CompanySystem
{
    internal struct Utility
    {
        public static HiringDate setHireDate(string _myHiredate)
        {
            string[] parsedDate = _myHiredate.Split('/');
            HiringDate h1 = new HiringDate(parsedDate[0], parsedDate[1], parsedDate[2]);
            return h1;
        }

        public static void AddEmployee(EmployeeSearch _employeeArr)
        {
            for (int i = 0; i < _employeeArr.Employee.Length; i++)
            {
                Console.WriteLine($"Enter details for employee {i + 1} ");
                Employee temp = new();

                int nationalID;
                do
                {
                    Console.Write("NationalID: ");

                    /* note: tryParse sets the out value to (0) on failure */

                    if (!int.TryParse(Console.ReadLine(), out nationalID))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                } while (nationalID == 0);


                /* NOTE: We have to pass by reference because here we are using structs !!!! 
                        where they are passed by value !!!! 
                */
                _employeeArr.setEmployeeSearch(i, nationalID, ref temp);

                addEmployeeName(ref temp);

                addEmployeeID(ref temp);

                addEmployeeSecurityLevel(ref temp);

                addEmployeeSalary(ref temp);

                addEmployeeHireDate(ref temp);

                addEmployeeGender(ref temp);

                _employeeArr.setEmployeeSearch(i, nationalID, ref temp);

                Console.WriteLine(" ==========================");
            }
        }

        public static void DisplayAllEmployees(Employee[] employeeArr)
        {
            foreach (var employee in employeeArr)
            {
                employee.getEmployeeData();
            }
        }

        public static void addEmployeeName(ref Employee temp)
        {
            Regex regex = new Regex(@"^[a-zA-Z\s]*$");

            do
            {
                Console.Write("Name: ");
                temp.Name = Console.ReadLine() ?? "";
            } while (string.IsNullOrWhiteSpace(temp.Name) || !regex.IsMatch(temp.Name));
        }

        public static void addEmployeeID(ref Employee temp)
        {
            int id;
            do
            {
                Console.Write("ID: ");

                /* note: tryParse sets the out value to (0) on failure */

                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            } while (id == 0);
            temp.Id = id;
        }

        public static void addEmployeeSecurityLevel(ref Employee temp)
        {
            Enums.SecurityLevels securityLevel;
            do
            {
                Console.Write("Security Level (guest,DBA,securityOfficer): ");

                /* https://learn.microsoft.com/en-us/dotnet/api/system.enum.tryparse?view=net-7.0#system-enum-tryparse(system-type-system-string-system-object@) */

                /*  VeryImportant:  
                    It's worth noting that Enum.TryParse will allow converting any string to an enumeration member, 
                 * even if the string does not match one of the defined enum values, because it will try to convert the input string to an enumeration member,
                 * regardless of whether the input string is one of the defined enum values or not. 
                 * So, the Enum.IsDefined method is used to verify that the input string is one of the defined enum values.
                 
                 https://stackoverflow.com/questions/6741649/enum-tryparse-returns-true-for-any-numeric-values
                */
            } while (
                !Enum.TryParse(Console.ReadLine(), out securityLevel)
                || !Enum.IsDefined(typeof(Enums.SecurityLevels), securityLevel)
            );

            temp.MySecurityLevel = securityLevel;
        }

        public static void addEmployeeSalary(ref Employee temp)
        {
            decimal salary;
            do
            {
                Console.Write("Salary: ");
            } while (!decimal.TryParse(Console.ReadLine(), out salary));
            temp.Salary = salary;
        }

        public static void addEmployeeHireDate(ref Employee temp)
        {
            string _myHiredate;
            bool hireDateFlag = true;
            do
            {
                Console.Write("Hire Date (dd/mm/yyyy): ");
                _myHiredate = Console.ReadLine();

                string[] parsedDate = _myHiredate.Split('/');

                if (parsedDate.Length == 3)
                {
                    int day,
                        month,
                        year;

                    /* tryParse will evaluate the string and checks if it's a number anyway
                        so you don't need to do anything extra

                     So this checked that each value is a number
                    */
                    if (
                        int.TryParse(parsedDate[0], out day)
                        && int.TryParse(parsedDate[1], out month)
                        && int.TryParse(parsedDate[2], out year)
                    )
                    {
                        if (
                            day > 0
                            && day < 32
                            && month > 0
                            && month < 13
                            && year > 1930
                            && year < 2023
                        )
                        {
                            temp.MyHireDate = new HiringDate(
                                parsedDate[0],
                                parsedDate[1],
                                parsedDate[2]
                            );
                            hireDateFlag = false;
                        }
                    }
                }
            } while (hireDateFlag);
        }

        public static void addEmployeeGender(ref Employee temp)
        {
            Enums.Gender gender;
            do
            {
                Console.Write("Gender (M/F): ");
            } while (
                !Enum.TryParse(Console.ReadLine(), out gender)
                || !Enum.IsDefined(typeof(Enums.Gender), gender)
            );
            temp.Gender = gender;
        }
    }
}
