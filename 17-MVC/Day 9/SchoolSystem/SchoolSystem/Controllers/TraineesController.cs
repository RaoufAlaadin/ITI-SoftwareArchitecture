using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSystem.Models;
using SchoolSystem.RepoServices;
using System.Linq;

namespace SchoolSystem.Controllers
{
    [Authorize]
    public class TraineesController : Controller
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly ITrackRepository _trackRepository;



        public TraineesController(ITraineeRepository traineeRepository,ITrackRepository trackRepository)
        {
            _traineeRepository = traineeRepository;
            _trackRepository = trackRepository;
        }

        public IActionResult Index()
        {
            var trainees = _traineeRepository.GetAll();
            return View(trainees);
        }

        public IActionResult Details(int id)
        {
            var trainee = _traineeRepository.GetById(id);

            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        public IActionResult Create()
        {
            ViewBag.TrackID = new SelectList(_trackRepository.GetAll(), "ID", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trainee trainee)
        {

            /* Important note: 
             * You have to put `?` for the properties you are not going to enter,
             * as they are considered required by default for the modelstate !! 
             
             if you do not put the `?` , then the Modelstate.IsValid
                    Will always result in => false 
            */

            if (ModelState.IsValid)
            {
                _traineeRepository.Add(trainee);
                return RedirectToAction(nameof(Index));
            }

            return View(trainee);
        }

        public IActionResult Edit(int id)
        {
            /* Note ====> 
             * This is important to fillup the dropdownMenu*/
            ViewBag.TrackID = new SelectList(_trackRepository.GetAll(), "ID", "Name");


            var trainee = _traineeRepository.GetById(id);

            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Trainee trainee)
        {
            if (id != trainee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _traineeRepository.Update(trainee);
                return RedirectToAction(nameof(Index));
            }

            return View(trainee);
        }

        public IActionResult Delete(int id)
        {
            var trainee = _traineeRepository.GetById(id);

            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _traineeRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
