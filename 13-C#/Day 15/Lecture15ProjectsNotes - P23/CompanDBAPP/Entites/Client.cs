using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanDBAPP.Entites
{
    public class Client
    {
            /* Imagine we don't have the source code for this Entity. 
             We set the columns config using Fluent API 
            */

        public int  CID {get; set;}

        public string FName { get; set;}
        public string MName { get; set; }

        public string LName { get; set; }

        public DateTime TimeStamp { get; } = DateTime.Now;

        public decimal Deposite { get; set; }

        /* Many to Many with branch
         
         1 client has many branches 
        and 1 Branch has many clients
        */
        public virtual ICollection<Branch> Branches { get; set; }   = new HashSet<Branch>();

        public virtual ICollection<EmployeeClient> EmployeeClients { get; set; } = new HashSet<EmployeeClient>();


    }
}
