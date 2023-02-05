using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyLayOffSystem
{
    internal class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }
        public List<Employee> Members { get; set; }

        public Club()
        {
            Members = new List<Employee>();
        }

        public void AddMember(Employee E)
        {
            Members.Add(E);
            E.EmployeeLayOff += RemoveMember;
        }

        ///CallBackMethod
        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            if ((sender is Employee emp) && (emp != null) && !(e.Cause == LayOffCause.Age) && (sender is not BoardMember))
            {
                Members.Remove(emp);
                emp.EmployeeLayOff -= RemoveMember;
                Console.WriteLine($"Employee {emp.EmployeeID} is removed from club {ClubName} because of {e.Cause}");
            }
            
        }

        public string DisplayClubList
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < Members.Count; i++)
                    stringBuilder.Append(Members[i].EmployeeID).Append(" , ");

                return stringBuilder.ToString();
            }
        }
    }
}
