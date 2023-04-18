using DepartementTask.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.DAL.Repos.TicketRepo
{
    public interface ITicketsRepo
    {
        public IEnumerable<Tickets> GetAll();
        public IEnumerable<Tickets> GetTicketsWithDepartementID(int id);
        public void AddDevelopersToTickets(int TicketId, Developer developer);
    }
}

