using DepartementTask.DAL.Data.Context;
using DepartementTask.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.DAL.Repos.DepartementRepo
{
    public interface IDepartementsRepo
    {

        public Departement? GetDepartementById(int Deptid);

    }
}
