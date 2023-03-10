using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVCApp.Models;

namespace FirstMVCApp.Controllers
{
    public class CarController : Controller
    {
        // GET: Employee
        public ActionResult GetAllCars()
        {
            List<Car> carlst = CarList.Cars;
            
            ViewBag.cars = carlst;
            return View();
        }

        public ActionResult SelectCarById(int id)
        {
            ViewBag.selectedCar
                = CarList.Cars.FirstOrDefault(x => x.Num == id);

            return View();
        }
        public ActionResult DeleteCar(int id)
        {
            var deletedCar
                = CarList.Cars.FirstOrDefault(x => x.Num == id);
            // remove that employee from our list. 
            CarList.Cars.Remove(deletedCar);

            return RedirectToAction("GetAllCars");  
        }


        #region Edit Car
        [HttpGet]
        public ActionResult EditCar(int id)
        {
            ViewBag.selectedCar
                = CarList.Cars.FirstOrDefault(x => x.Num == id);

            return View();
        }


        [HttpPost]
        public ActionResult EditCar(int Num, string color, string model, string manufacture)
        {
            // We do not update the ID, that's why we don't have a problem here.
            Car editedCar
               = CarList.Cars.FirstOrDefault(x => x.Num == Num);

            editedCar.Color = color;
            editedCar.Model = model;
            editedCar.Manufacture = manufacture;


            return RedirectToAction("GetAllCars");

        }
        #endregion


        #region Create New Car

        [HttpGet]
        public ActionResult CreateNewCar()
        {
            ViewBag.newCarID = CarList.Cars.Max(x => x.Num) + 1; 
            return View();
        }


        [HttpPost]
       
        public ActionResult CreateNewCar(int Num, string color, string model, string Manfacture)
        {
            

            Car newCar = new Car();

            newCar.Num = Num;
            newCar.Color = color;
            newCar.Model = model;
            newCar.Manufacture = Manfacture;

            CarList.Cars.Add(newCar);

            return RedirectToAction("GetAllCars");

        }
        #endregion



    }
}