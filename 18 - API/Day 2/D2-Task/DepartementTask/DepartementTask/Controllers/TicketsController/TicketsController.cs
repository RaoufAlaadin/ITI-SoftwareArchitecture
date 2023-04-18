using DepartementTask.BL.Managers.TicketsManager.TicketManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartementTaskApi.Controllers.TicketsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsManager _ticketsManager1;
        public TicketsController(ITicketsManager ticketsManager)
        {
            _ticketsManager1=ticketsManager;
        }
        [HttpGet]
        public IActionResult GetAllTickets() 
        {
            return Ok(_ticketsManager1.GetTicketDtos());
        }
        [HttpGet("{DeptId}")]
        public IActionResult GetTicketsdTO(int DeptId)
        {
            return Ok(_ticketsManager1.GetTicketDtosWithDevelopersCount(DeptId));
        }


    }
}
