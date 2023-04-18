using AutoMapper;
using DepartementTask.BL.DTOs.Ticket;
using DepartementTask.BL.DTOs.TicketDto;
using DepartementTask.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DepartementTask.BL.Profiles
{
    public class TicketProfile:Profile
    {
        public TicketProfile()
        {
            CreateMap<Tickets,TicketDto>();
            CreateMap<Tickets, TicketsWithNumberOfIt_sDevelopersDto>().ForMember(
                dest => dest.DevelopersCount,
                opt => opt.MapFrom<DeveloperCountResolver>());
        }
        public class DeveloperCountResolver : IValueResolver<Tickets, TicketsWithNumberOfIt_sDevelopersDto, int>
        {
            public int Resolve(Tickets source, TicketsWithNumberOfIt_sDevelopersDto destination, int member, ResolutionContext context)
            {
                return source.developer?.Count() ?? 0;
            }
        }
    }
}
