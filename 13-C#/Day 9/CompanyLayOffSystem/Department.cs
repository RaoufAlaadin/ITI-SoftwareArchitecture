using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CompanyLayOffSystem
{
    class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public List<Employee> Staff { get; set; }

        public Department()
        {
            Staff = new List<Employee>();
        }

        public void AddStaff(Employee E)
        {
            Staff.Add(E);
            E.EmployeeLayOff += Employee_EmployeeLayOff;
            E.EmployeeLayOff += RemoveStaff;

        }

        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            // e holds the story about this event ==> the cause the employee raised the event
            if ((sender is Employee emp) && (emp != null) )
            {
                    /* Sender gives me the object that made the event invokation
                     * This helps me in the removal of the subscription that I made before to that exact object.
                     */
                Staff.Remove(emp);
                emp.EmployeeLayOff -= RemoveStaff;
                Console.WriteLine(
                    $"Employee {emp.EmployeeID} is removed from Department {DeptName} because of {e.Cause}"
                );
            }
        }

        public string DisplayDepartmentList
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < Staff.Count; i++)
                    stringBuilder.Append(Staff[i].EmployeeID).Append(" , ");

                return stringBuilder.ToString();
            }
        }

        public static void Employee_EmployeeLayOff(object sender, EmployeeLayOffEventArgs e)
        {
            if ((sender is Employee emp) && (emp != null) )
            {
                /* if this method called back to the invoktion of the event
                 and the reason wasn't one the below, it won't activate 
                */
                if ((e.Cause == LayOffCause.VacationStock) || (e.Cause == LayOffCause.Age) || (e.Cause == LayOffCause.Resign))
                {
                    emp.EmployeeLayOff -= Employee_EmployeeLayOff;
                    Console.WriteLine($"Employee {emp.EmployeeID} is laid-off because of {e.Cause}");
                }
               
            }
        }
    }
}
