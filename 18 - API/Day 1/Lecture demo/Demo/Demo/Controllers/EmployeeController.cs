using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Demo.DTO;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly ITIEntity context; 

        public EmployeeController (ITIEntity context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAllEmp()
        {

            var emplList = context.employees.Include(s=>s.Department).ToList();

            return Ok(emplList);
        }


        [HttpGet("{id:int}",Name ="oneEmployeeRoute")]
        public IActionResult GetEmp(int id)
        {

            var emp = context.employees
                            .Include(s => s.Department)
                            .FirstOrDefault(e => e.Id == id);

            EmployeeDataWithDepartmentNameDTO EmpDto =
                new EmployeeDataWithDepartmentNameDTO()
                {
                    DepartmentName = emp.Department.Name,
                    StudentName = emp.Name,
                    ID =emp.Id,
                    Address = emp.Address
               
                };
            return Ok(EmpDto);
        }
    }
}
