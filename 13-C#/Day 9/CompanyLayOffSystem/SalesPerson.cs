using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CompanyLayOffSystem
{
    internal class SalesPerson : Employee
    {
        /*     ====Sales Employee & Board Member===
         *
               1- Sales Employee Doesn’t have Vacation Stock
               2- Sales Employee Will not be Fired if his/her Vacation Stock <0
   
   
               3- Sales Employee have a target to Achieve
               4- Sales Employee will be Fired if Failed to Achieve Sales Target
               
   
   
         */

        public int AchievedTarget { get; set; }

        public bool CheckTarget(int Quota)
        {
            if (Quota < AchievedTarget)
            {
                /* This will invoke the the below method with this specific cause*/
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.Target });

                return false;
            }

            return true;
        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            /* overriding the event handler method is important for many resons 
             if you try to call sales1.requestVacation()
            and the limit is based, it will layoff the sales person which is wrong for bussines rules
            
             so by overriding the function, requestVacation() calls the new overriden fucntion 
            with it's cause "vacationStock".
            
             and because it's not allowed here, we successfully prevented the event invoktion
                **Note** ==> use the debugger to trace it and it will become more clear. 
                *
             We allowed the age here as at the begaining of the task we were told it's a must for any Employee
             */
            if (e.Cause == LayOffCause.Target || e.Cause == LayOffCause.Age)
                base.OnEmployeeLayOff(e);
        }
    }
}
