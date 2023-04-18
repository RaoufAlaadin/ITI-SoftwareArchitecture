using AutoMapper;
using DepartementTask.BL.DTOs.Ticket;
using DepartementTask.BL.DTOs.TicketDto;
using DepartementTask.BL.Managers.TicketsManager.TicketManager;
using DepartementTask.DAL.Data.Context;
using DepartementTask.DAL.Repos.TicketRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.BL.Managers.TicketManager
{
    public class TicketsManager : ITicketsManager
    {
        
        private readonly ITicketsRepo _ticketsRepo;
        private readonly IMapper _mapper;
        public TicketsManager(ITicketsRepo ticketsRepo, IMapper mapper)
        {
            _ticketsRepo=ticketsRepo;
            _mapper=mapper;
        }
        public IEnumerable<TicketDto> GetTicketDtos()
        {
            var Tickets= _ticketsRepo.GetAll();
            return _mapper.Map<List<TicketDto>>(Tickets);

        }
        public IEnumerable<TicketsWithNumberOfIt_sDevelopersDto> GetTicketDtosWithDevelopersCount(int DeptId)
        {
            var TicketsinDepartement = _ticketsRepo.GetTicketsWithDepartementID(DeptId).ToList();
            var tickets= _mapper.Map<List<TicketsWithNumberOfIt_sDevelopersDto>>(TicketsinDepartement);
            for(int i =0;i<tickets.Count;i++)
            {
                tickets[i].DevelopersCount = TicketsinDepartement[i].developer.Count();
            }
            return tickets;
        }

    }
}
