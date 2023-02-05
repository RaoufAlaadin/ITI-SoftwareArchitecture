using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyLayOffSystem
{
    internal class BoardMember : Employee
    {
        /*     ====Sales Employee & Board Member===
      *
           
            5- Board Member has no retiring Age (will not be Fired if AGE > 60)
            6- Board Member is not a Full time Employee (Has no vacation Stock)
            7- Board Member will be layoff from the Company in case He/She
            Resigned.
            8- Board Member will forever be a Member of Company Clubs


      */

        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.Resign });
        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if (e.Cause == LayOffCause.Resign)
                base.OnEmployeeLayOff(e);
        }
    }
}
