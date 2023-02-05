using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyLayOffSystem
{
    class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }
        public DateTime BirthDate { get; set; }
        public int VacationStock { get; set; }

        public bool RequestVacation(DateTime from, DateTime to)
        {
            
            /* When the call is made, if he was already out of days 
                or if the requested amount of days are more than what is allowed for him
                => he will get layed off 
            */
            if ((VacationStock < 0) || (VacationStock < (to - from).Days))
            {
                // Invoke event.
                OnEmployeeLayOff(new EmployeeLayOffEventArgs()
                {
                    Cause = LayOffCause.VacationStock
                });
                return false;
            }

            VacationStock -= (to - from).Days;

            return true;
        }

        public void EndOfYearOperation()
        {
            var age = (DateTime.Now - BirthDate).TotalDays / 365.25;
            if (age > 60)
            {
                // Invoke event.
                OnEmployeeLayOff(new EmployeeLayOffEventArgs()
                {
                    Cause = LayOffCause.Age
                });
            }
        }


        

    }



    public enum LayOffCause
    {
        VacationStock,
        Age,
        Target,
        Resign
    }

    public class EmployeeLayOffEventArgs : EventArgs
    {
        public LayOffCause Cause { get; set; }
    }

}
