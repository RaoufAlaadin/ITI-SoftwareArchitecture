using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.BL.DTOs.TicketDto
{
    public class TicketsWithNumberOfIt_sDevelopersDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int DevelopersCount { get; set; }
    }
}
