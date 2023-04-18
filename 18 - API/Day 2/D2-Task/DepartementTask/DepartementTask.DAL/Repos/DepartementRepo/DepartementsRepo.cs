using DepartementTask.DAL.Data.Context;
using DepartementTask.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.DAL.Repos.DepartementRepo
{
    public class DepartementsRepo:IDepartementsRepo
    {
        private readonly DepartementContext _departementContext;
        public DepartementsRepo(DepartementContext departementContext)
        {
            _departementContext = departementContext;
        }
        public Departement? GetDepartementById(int Deptid)
        {
            return _departementContext.departements.Include(D=>D.tickets).FirstOrDefault(D => D.Id == Deptid);
        }
    }
}
