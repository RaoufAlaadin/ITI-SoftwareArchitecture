using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanDBAPP.Entites
{
    public class EmployeeClient
    {
        /// <summary>
        /// We created this table by hand, 
        /// While normally it will be created for us automatically as soon as 
        /// both Entities have Icollection. 
        /// 
        /// Benifit of doing it manually, that we can add other attributes to the mix. 
        /// </summary>
        /// The following is the table columns
        public int EmployeeEID { get; set; }
        public int ClientCID { get; set; }
        public DateTime Visit { get; set; }

        /// Navigational properties
        public virtual Employee Employee { get; set; }
        public virtual Client Client { get; set; }

    }
}
