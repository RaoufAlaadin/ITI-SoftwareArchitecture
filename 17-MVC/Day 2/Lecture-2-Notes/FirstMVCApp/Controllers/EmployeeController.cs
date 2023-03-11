using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVCApp.Models;

namespace FirstMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult getAll()
        {
            List<Employee> emplst = EmployeeList.Employees;
            
            ViewBag.Emps = emplst;
            return View();
        }

        public ActionResult getByID(int id)
        {
            /* Employee emp 
                 = EmployeeList.Employees.FirstOrDefault(x => x.Id == id);  

             ViewBag.selectedEmp = emp;*/

            ViewBag.selectedEmp
                = EmployeeList.Employees.FirstOrDefault(x => x.Id == id);


            return View();
        }
        public ActionResult delete(int id)
        {
           
            var deletedEmp
                = EmployeeList.Employees.FirstOrDefault(x => x.Id == id);
            // remove that employee from our list. 
            EmployeeList.Employees.Remove(deletedEmp);

            return RedirectToAction("getAll");  
            
            /* Important note !! 
            if we used 
                                return View("getAll") 
                                                            instead, 
            Then it would return the previously created view for that action
            without doing the action again and updating the `getAll` view. 

            also => retunr getAll();   won't work and gives an Error.

            as the last return need a view that has the same name as the action
            which is `delete. 
            
            */
        }

        #region Edit Employee
        [HttpGet]
        // In responce to a GET request (When we press `Edit`) 
        public ActionResult Edit(int id)
        {
            ViewBag.selectedEmp
                = EmployeeList.Employees.FirstOrDefault(x => x.Id == id);


            return View();
        }


        [HttpPost]
        // In responce to a POST request (When the `save btn` is pressed) 

        // There is 3 ways for creating this method,The Dr told us it will 
        // Be explained in the next lecture. 
        public ActionResult Edit(int id, string name, int age, string email)
        {
            // We do not update the ID, that's why we don't have a problem here.
            Employee editedEmp
               = EmployeeList.Employees.FirstOrDefault(x => x.Id == id);

            editedEmp.Name = name;
            editedEmp.Age = age;
            editedEmp.Email = email;


            return RedirectToAction("getAll");

        }
        #endregion

        #region Create  Employee
        [HttpGet]
        // In responce to a GET request (When we press `Edit`) 
        public ActionResult Create()
        {
            ViewBag.newEmpID = EmployeeList.Employees.Max(x => x.Id) + 1; 
            return View();
        }


        [HttpPost]
        // In responce to a POST request (When the `save btn` is pressed) 

        // There is 3 ways for creating this method,The Dr told us it will 
        // Be explained in the next lecture. 


        /// How the paramters are input need more search
        public ActionResult Create(int id, string name , int age, string email)
        {
            // We do not update the ID, that's why we don't have a problem here.

            Employee newEmp = new Employee();

            newEmp.Id = id;
            newEmp.Name = name;
            newEmp.Age = age;
            newEmp.Email = email;

            EmployeeList.Employees.Add(newEmp);


            return RedirectToAction("getAll");

        }
        #endregion



    }
}