using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.DAL.Data.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DepartementId { get; set; }
        public Departement? Departement { get; set; }
        public IEnumerable<Developer> developer { get; set; } = new List<Developer>();
    }
}
