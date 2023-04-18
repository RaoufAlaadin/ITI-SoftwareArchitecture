using AutoMapper;
using DepartementTask.BL.DTOs.DepartementDto;
using DepartementTask.BL.Managers.TicketsManager.TicketManager;
using DepartementTask.DAL.Data.Models;
using DepartementTask.DAL.Repos.DepartementRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.BL.Managers.DoctorManager
{
    public class DepartementManager:IDepartementManager
    {
        private readonly IDepartementsRepo _departementsRepo;
        private readonly ITicketsManager _ticketsManager;
        private readonly IMapper _mapper;
        public DepartementManager(IDepartementsRepo departementsRepo
            , ITicketsManager ticketsManager
            , IMapper mapper)
        {
            _departementsRepo= departementsRepo;
            _ticketsManager= ticketsManager;
            _mapper = mapper;
        }
        public DepartementWithTicketsWithDevelopersCountDto? GetDepartementById(int Deptid)
        {
            var NewTicketsWithDevelopersCount = _ticketsManager.GetTicketDtosWithDevelopersCount(Deptid);
            var OrginalDept = _departementsRepo.GetDepartementById(Deptid);
            var DeptDto = _mapper.Map<DepartementWithTicketsWithDevelopersCountDto>(OrginalDept);
            DeptDto.TicketsWithDevelopersCount = NewTicketsWithDevelopersCount;
            return DeptDto;
        }

    }
}
