using D01Cars.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using D01Cars.Filtters;
using System.Diagnostics.Metrics;

namespace D01Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
        
    {

        private readonly ILogger<CarController> _logger;
        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<car>> getAll()
        {
            _logger.LogCritical("get All Requests");
            if (!CarList.cars.Any())
            {
                return NotFound();
            }
            return CarList.cars;

        }


        [HttpGet("{id:int}")]
        public ActionResult<car> getByID(int id)
        {
            _logger.LogCritical("getById Request");

            var car = CarList.cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return car;//return 200
        }

        //Created 201 V1
        [HttpPost]
        [Route("v1")]
        public ActionResult NewV1 (car car)
        {
            if(car == null)
            {
               return BadRequest();
            }
            car.Id = new Random().Next(10, 1000);
            car.Type = "Gas";
            //increase counter
            car.counter++;
            CarList.cars.Add(car);
             
            return CreatedAtAction(
                actionName: "GetById",
                routeValues: new { id = car.Id },
                value: new { Message = "Car has been Successfuly" }); 

        }
        //Created 201 V1
        [HttpPost]
        [Route("v2")]
        [ValidatCarType]
        public ActionResult NewV2(car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            car.Id = new Random().Next(10, 1000);
            car.counter++;
            CarList.cars.Add(car);

            return CreatedAtAction(
                actionName: "GetById",
                routeValues: new { id = car.Id },
                value: new { Message = "Car has been Successfuly" });

        }

        //Update
        [HttpPut("{id:int}")]
        public ActionResult Update(int id , car car )
        {
            var carToUpdate = CarList.cars.Find(c => c.Id == id);
            if(id !=car.Id)
            {
                return NotFound();
            }
            carToUpdate.Name = car.Name;
            carToUpdate.Model = car.Model;
            return NoContent();

        }

        //Delete
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var car = CarList.cars.Find(c => c.Id == id);
            if(car == null)
            {
                return NotFound();
            }
            CarList.cars.Remove(car);
            return NoContent();
        }

        //Action Counter
        [HttpGet("Requestcount") ]
        public ActionResult<int> getCounter()
        {
            return car.counter;

        }
    }

 }

