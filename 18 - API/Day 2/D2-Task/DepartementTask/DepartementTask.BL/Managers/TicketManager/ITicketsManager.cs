using DepartementTask.BL.DTOs.Ticket;
using DepartementTask.BL.DTOs.TicketDto;
using DepartementTask.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.BL.Managers.TicketsManager.TicketManager
{
    public interface ITicketsManager
    {
        public IEnumerable<TicketDto> GetTicketDtos();
        public IEnumerable<TicketsWithNumberOfIt_sDevelopersDto> GetTicketDtosWithDevelopersCount(int DeptId);
        
    }
}
