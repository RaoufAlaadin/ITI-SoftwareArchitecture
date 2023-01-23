
/*  https://learn.microsoft.com/en-us/dotnet/api/system.enum.parse?view=net-7.0 */



/* removing the delete from a securityOfficer makes  him a DBA *//*

using System.Security.Cryptography;

Console.WriteLine(" ======SecurityLevels testing=======");

SecurityLevels roleTest = SecurityLevels.securityOfficer;
Console.WriteLine(roleTest);

roleTest ^= SecurityLevels.Delete;
Console.WriteLine(roleTest);

Console.WriteLine(" ==========================");



//Employee[] employeeArr =
//{
//    new Employee(10,SecurityLevels.guest,0,"20/1/2023","M"),
//    new Employee(15,SecurityLevels.DBA,7000,"20/1/2023","M"),
//    new Employee(20,SecurityLevels.securityOfficer,10000,"20/1/2023","M")

//};


while (true)
{
    Console.Write("Enter number of employees: ");
    int numberOfEmployees = int.Parse(Console.ReadLine());
    Console.WriteLine(" ==========================");

    Employee[] employeeArr = new Employee[numberOfEmployees]; // Array definition

    AddEmployee(employeeArr);

    Console.WriteLine(" ==========================");
    Console.WriteLine("Press Q to view the array");
    if (Console.ReadKey().Key == ConsoleKey.Q)
    {
        Console.Clear(); // clears the window screen 
        DisplayAllEmployees(employeeArr);

        break; // breaks the while loop 
    }
}

*//* write lets us  write in the same line *//*
static void AddEmployee(Employee[] employeeArr)
{
   
    for (int i = 0; i < employeeArr.Length; i++)
    {
        Console.WriteLine($"Enter details for employee { i + 1} ");
        // 1- ID
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        // 2- securityLevel
        Console.Write("Security Level (guest,DBA,securityOfficer): ");
        SecurityLevels securityLevel = (SecurityLevels)Enum.Parse(typeof(SecurityLevels), Console.ReadLine());
        // 3- Salary
        Console.Write("Salary: ");
        int salary = int.Parse(Console.ReadLine());
        // 4- HireDate
        Console.Write("Hire Date (dd/mm/yyyy): ");
        string hireDate = Console.ReadLine();
        // 5- Gender 
        Console.Write("Gender (M/F): ");
        Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());

        // main Array 
        employeeArr[i] = new Employee(id, securityLevel, salary, hireDate, gender);

        Console.WriteLine(" ==========================");
    }

}

static void DisplayAllEmployees(Employee[] employeeArr)
{
    foreach (var employee in employeeArr)
    {
        employee.getEmployeeData();
    }
}



Console.ReadKey(); // prevents the console from exit(0) until I press any key.




[Flags]
enum SecurityLevels:byte
{

    Read = 1,
    Write = 2,
    Execute = 4,
    Delete = 8,
    
    guest = Read,
    developer = Read | Write,
    secretary = Write,
    DBA = Read | Write | Execute ,
    securityOfficer = Read | Write | Execute | Delete

}

struct Employee
{

    public int id;
    public SecurityLevels mySecurityLevel;

    public int salary;
    public HiringDate myHireDate;
    public Gender gender;

    public Employee(int _id, SecurityLevels _mySecurityLevel, int _salary, string _myHireDate, Gender _gender)
    {

        id = _id;
        mySecurityLevel = _mySecurityLevel;
        salary = _salary;
        gender = _gender;
        myHireDate = setHireDate(_myHireDate);

    }

    #region Getters

    public int GetId()
    {
        return id;
    }
    

 
    public SecurityLevels GetMySecurityLevel()
    {
        return mySecurityLevel;
    }
   

 
    public int GetSalary()
    {
        return salary;
    }



    public HiringDate GetMyHireDate()
    {
        return myHireDate;
    }



    public Gender GetGender()
    {
        return gender;
    }


    #endregion


    #region Setters

  
    public void SetId(int _id)
    {
        id = _id;
    }

   
    public void SetMySecurityLevel(SecurityLevels _mySecurityLevel)
    {
        mySecurityLevel = _mySecurityLevel;
    }

    
    
    public void SetSalary(int _salary)
    {
        salary = _salary;
    }

   
    public void SetMyHireDate(string _myHireDate)
    {
        myHireDate = setHireDate(_myHireDate);
    }

   
    public void SetGender(Gender _gender)
    {
        gender = _gender;
    }
    #endregion




    public void getEmployeeData()
    {
        Console.WriteLine(this.ToString());
    }


    public override string ToString()
    {


        return $"""

            Emp ID : {this.id}
            "SecurityLevel : {this.mySecurityLevel}
            "Salary : {this.salary:C}
            "{myHireDate.ToString()}
            "Gender : {this.gender}
            "==============================
            
            """;


        *//*          you can also use this
         * 
         * return $"Emp ID : {this.id}\n" +
            $"SecurityLevel : {this.mySecurityLevel}\n" +
            $"Salary : {this.salary:C}\n" +
            $"{myHireDate.ToString()}\n" +
            $"Gender : {this.gender}\n" +
            $"==============================";*//*


    }

    
    public HiringDate setHireDate(string _myHiredate)
    {
        string[] parsedDate = _myHiredate.Split('/');
        HiringDate h1 = new HiringDate(parsedDate[0], parsedDate[1], parsedDate[2]);
        return h1;
    }

}


struct HiringDate
{
    public string day;
    public string month;
    public string year;

    public HiringDate(string _day, string _month, string _year)
    {
        day = _day;
        month = _month; 
        year = _year;   
    }

   
    public override string  ToString()
    {
        return $"Birthdate is: {this.day}/{this.month}/{this.year}";
       
    }

}



enum Gender:byte
{
    M , 
    F 
}

*/