using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.DAL.Data.Models
{
    public class Departement
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Tickets> tickets { get; set; }=new List<Tickets>();
    }
}
