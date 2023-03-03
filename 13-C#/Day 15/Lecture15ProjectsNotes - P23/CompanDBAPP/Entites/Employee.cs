using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanDBAPP.Entites
{
    public class Employee
    {
        
        /* [Keyless] Keyless Entites is used to map a view. */

        [Key]
        public int EId { get; set; }
        [MaxLength(40)]
        public string FName { get; set; }

        [StringLength(2,MinimumLength = 2 )] // stating both max/min = 2 characters; 
        public string MName { get; set; } // optional // is only 2 chars


        [MaxLength(40)]
        public string LName { get; set; }

        [Column(TypeName = "Money")]
        public decimal Salary { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Phone]
        [MaxLength(15)]
        public string? Phone { get; set; }   

        [NotMapped] // not tracked in the database. 
        public string FullName { get => $"{FName}{MName ?? string.Empty} {LName}"; }   // we check null for Mname as it's optional.

        //connect Employee and Branch
        //Navigational Property.
        public virtual Branch? Branch { get; set; }

        public virtual ICollection<EmployeeClient> EmployeeClients { get; set; } = new HashSet<EmployeeClient>();
    }
}
