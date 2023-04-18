using Demo.Models;
using System.Collections.Generic;

namespace Demo.DTO
{
    public class DepartmentDetailWithEmployeeNameDTO
    {

        public int ID { get; set; }
        public string DeptName { get; set; }

        // Intiliazing the refernce to point at a list is important 
        // to avoid null excpetion when adding.
        public List<string> EmployeeNames { get; set; } = new List<string>();   
    }
}
