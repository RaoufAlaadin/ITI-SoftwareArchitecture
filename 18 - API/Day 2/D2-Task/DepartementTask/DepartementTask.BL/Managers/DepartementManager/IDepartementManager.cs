using DepartementTask.BL.DTOs.DepartementDto;
using DepartementTask.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.BL.Managers.DoctorManager
{
    public interface IDepartementManager
    {
        public DepartementWithTicketsWithDevelopersCountDto? GetDepartementById(int Deptid);
    }
}
