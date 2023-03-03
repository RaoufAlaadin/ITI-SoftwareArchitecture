using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanDBAPP.Entites
{
    public class Branch
    {
        public int ID { get; set; } 
        public string Name { get; set; }

        public string City { get; set; }

        /* Representing the 1:M relation with the Employee Entity
         One Employee work for one Branch
         Branch has many employees */

        //Navigational Property.

        public virtual List<Employee>? Employees { get; set; } = new();


        /* Many to Many with Client
         
         1 client has many branches 
        and 1 Branch has many clients
        */
        public virtual ICollection<Client> Clients { get; set; } = new HashSet<Client>();
    }
}
