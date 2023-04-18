using AutoMapper;
using DepartementTask.BL.DTOs.DepartementDto;
using DepartementTask.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.BL.Profiles
{
    public class DepartementProfile:Profile
    {
        public DepartementProfile()
        {
            CreateMap<Departement, DepartementWithTicketsWithDevelopersCountDto>();
        }
    }
}
