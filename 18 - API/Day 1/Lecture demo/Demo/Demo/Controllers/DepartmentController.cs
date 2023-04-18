using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Demo.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Demo.Controllers
{
    [Route("api/[controller]")] //api/Department => unifrom Interface (restful)
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        /*WARNING =>  Ofcourse we should have used repository pattern*/
        private readonly ITIEntity _context;

        public DepartmentController(ITIEntity context)
        {
            _context = context;
        }


        [HttpGet]

        public IActionResult GetAllDepartment() { 
        
        List<Department> deptList = _context.Department.ToList();

            return Ok(deptList);


        }

        //[HttpGet]
        //public ActionResult<List<Department>> GetAllDepartment()
        //{

        //    List<Department> deptList = _context.Department.ToList();

        //    //return Ok(deptList);
        //    return deptList;


        //}

        [HttpGet("{id:int}",Name ="GetOneDeptRoute")]
        //[Route("{id:int}")]

        public IActionResult GetByID(int id) { 
        

            //Department dept = _context.Department.SingleOrDefault(p => p.Id== id);
            Department dept = _context.Department.FirstOrDefault(d => d.Id== id);

            return Ok(dept);

        }

        [HttpGet("Emp/{id:int}")]

        public IActionResult GetByIDDTO(int id)
        {


            //Department dept = _context.Department.SingleOrDefault(p => p.Id== id);
            Department dept = _context.Department
                .Include(d=>d.Employee)
                .FirstOrDefault(d => d.Id == id);



            var deptDto = new DepartmentDetailWithEmployeeNameDTO()
            {
                DeptName = dept.Name,
                ID = dept.Id
            };

            //var employeeNames = dept.Employee.Select(e => e.Name).ToList();

            foreach (var emp in dept.Employee)
            {
                deptDto.EmployeeNames.Add(emp.Name);
            }

            return Ok(deptDto);


        }











        [HttpGet("{Name:Alpha}")]

        public IActionResult GetByName(string Name)
        {


            //Department dept = _context.Department.SingleOrDefault(p => p.Id== id);
            Department dept = _context.Department.FirstOrDefault(d => d.Name == Name);

            return Ok(dept);

        }

        [HttpPost]
        public IActionResult PostAllDepartment(Department Dept) { 
        
            // compares the Model we referenced, to the one sent in the request.
            if(ModelState.IsValid == true)
            {
                _context.Department.Add(Dept);
                _context.SaveChanges();

                //return Ok("Saved"); // 200 

                /* Note: We called the `Dept.Id` --only after-- SaveChanges(), 
                 as it will store the object in database and it will get an Id from 
                the `Identity`
                */

                /* How to get the current domain?! (Important when publishing)
                 
                 */

                string url = Url.Link("GetOneDeptRoute", new { id = Dept.Id });

                // (Location of the new object , the new object)
                //return Created("http://localhost:38931/api/Department/" + Dept.Id, Dept);

                return Created(url, Dept);




                /* How to get the current domain?! (Important when publishing)
                 
                 */


            }

            //return BadRequest("Department not valid"); //400

            // it's better to send the modelState to learn the cause.
            return BadRequest(ModelState); 
        }

        //[HttpPatch] on a specific field only.

        /* We get the `id` => from the `Url`
            dept (the updated object) => from the `Body` 
         */

        [HttpPut("{id:int}")]

        public IActionResult Update([FromRoute] int id, [FromBody] Department dept) { 
            
            // Have the use ModelState everytime I add to the database.
            if(ModelState.IsValid == true)
            {
                
                var oldDept = _context.Department.FirstOrDefault(d => d.Id == id);

                if (oldDept != null)
                {
                    /*xxxxxxxxxxxxxxxxxx ==>
                     * these methods are NOT working 
                     * 
                 * Note: Any method will still require => _context.SaveChanges();
                 * 
                Method-1
                    _context.Entry(dept).State = EntityState.Modified;

                Method-2
                _context.Update(dept);
                 */


                    oldDept.Name = dept.Name;
                    oldDept.Manger = dept.Manger;

                    _context.SaveChanges();

                    // 204 => no content => used in update or delete
                    return StatusCode(204, oldDept);

                }

                return BadRequest("Id is not valid.");
                

            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Remove([FromRoute] int id) {

            var oldDept = _context.Department.FirstOrDefault(d => d.Id == id);

            if (oldDept != null)
            {
                // Have a big chance of throwing an expecetion in Database.
                // So we use try and catch.
                try
                {
                    _context.Department.Remove(oldDept);
                    _context.SaveChanges();

                    return StatusCode(204, "Recored remove Succes");


                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
               

            }

            return BadRequest("Id not found");
        }


    }
}
