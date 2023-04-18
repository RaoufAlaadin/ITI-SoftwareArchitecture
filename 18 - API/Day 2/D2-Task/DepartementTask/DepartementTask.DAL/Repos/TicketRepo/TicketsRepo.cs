using DepartementTask.DAL.Data.Context;
using DepartementTask.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.DAL.Repos.TicketRepo
{
    public class TicketsRepo:ITicketsRepo
    {
        private readonly DepartementContext _departementContext;
        public TicketsRepo(DepartementContext departementContext)
        {
            _departementContext= departementContext;
        }
        public IEnumerable<Tickets> GetAll()
        {
            return _departementContext.Set<Tickets>();
        }
        public IEnumerable<Tickets> GetTicketsWithDepartementID(int DeptId)
        {
            return _departementContext.Set<Tickets>().Include(T=>T.developer).Where(T => T.DepartementId == DeptId);
        }

        public void AddDevelopersToTickets(int TicketId,Developer developer)
        {
           var ticketstoAddDeveloperstoit= _departementContext.Set<Tickets>().
                FirstOrDefault(T => T.Id == TicketId);

            ticketstoAddDeveloperstoit?.developer.Append(developer);
            SaveChanges();
        }
        public void SaveChanges()
        {
            _departementContext.SaveChanges();
        }

    }
}
