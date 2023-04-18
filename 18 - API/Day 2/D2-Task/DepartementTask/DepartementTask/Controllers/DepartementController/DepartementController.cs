using DepartementTask.BL.Managers.DoctorManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartementTaskApi.Controllers.DepartementController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : ControllerBase
    {
        private readonly IDepartementManager _manager;
        public DepartementController(IDepartementManager manager)
        {
            _manager = manager;
        }
        [HttpGet("{DeptId}")]
        public IActionResult GetDepartementDtoWithId(int DeptId)
        {
            return Ok(_manager.GetDepartementById(DeptId));
        }
    }
}
