using DepartementTask.BL.DTOs.TicketDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.BL.DTOs.DepartementDto
{
    public class DepartementWithTicketsWithDevelopersCountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;  
        public IEnumerable<TicketsWithNumberOfIt_sDevelopersDto> TicketsWithDevelopersCount { get; set; }=
                new HashSet<TicketsWithNumberOfIt_sDevelopersDto>();
    }
}
