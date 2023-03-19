using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using SchoolSystem.RepoServices;

namespace SchoolSystem.Controllers
{
    [Authorize]
    public class TraineeCoursesController : Controller
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ITraineeCourseRepository _traineeCourseRepository;

        public TraineeCoursesController(ITraineeRepository traineeRepository, ICourseRepository courseRepository, ITraineeCourseRepository traineeCourseRepository)
        {
            _traineeRepository = traineeRepository;
            _courseRepository = courseRepository;
            _traineeCourseRepository = traineeCourseRepository;
        }


        // GET: TraineeCourses
        public IActionResult Index()
        {
            var traineeCourses = _traineeCourseRepository.GetAll();
            return View(traineeCourses);
        }

        // GET: TraineeCourses/Details/5
        public IActionResult Details(int? traineeId, int? courseId)
        {
            if (traineeId == null || courseId == null)
            {
                return NotFound();
            }

            var _traineeld = _traineeCourseRepository.GetById(traineeId.Value, courseId.Value);
            if (_traineeld == null)
            {
                return NotFound();
            }

            return View(_traineeld);
        }


        // GET: Trainees/Create
        public IActionResult Create()
        {

            ViewBag.TraineeID = new SelectList(_traineeRepository.GetAll(), "ID", "Name");
            ViewBag.CourseID = new SelectList(_courseRepository.GetAll(), "ID", "Topic");


            return View();
        }

        // POST: Trainees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TraineeID,CourseID,notes")] TraineeCourse traineeld)
        {
                /* We had to repeat this viewbag here because we reset if we find serverSide error
                  have to find a better way. 
                */
            ViewBag.TraineeID = new SelectList(_traineeRepository.GetAll(), "ID", "Name");
            ViewBag.CourseID = new SelectList(_courseRepository.GetAll(), "ID", "Topic");


            #region Important note on Modelstate.AddModelError => to handle inputing the same record.

            /* Model-level errors are errors that are associated with the entire model object, 
             * rather than with a specific property of the model. These errors are added to the `ModelState` 
             * object using an empty key.

                    For example:

                    ```csharp
                    ModelState.AddModelError("", "This trainee is already enrolled in this course.");
                    ```

                    Property-level errors, on the other hand, are errors that are associated with a specific property of the model. These errors are added to the `ModelState` object using the name of the property as the key.

                    For example:

                    ```csharp
                    ModelState.AddModelError("TraineesId", "The Trainee field is required.");
                    ```

                    In this case, we're adding an error message to the `TraineesId` property of our model. This error message will be displayed next to the `TraineesId` form field if we have an appropriate validation message element in our view.

                    Is this what you were looking for?
            */
            #endregion

            var _traineeld = _traineeCourseRepository.GetById(traineeld.TraineeID, traineeld.CourseID);
            if (_traineeld != null)
            {
                ModelState.AddModelError("", "This trainee is already enrolled in this course.");
                return View(traineeld);
            }



            if (ModelState.IsValid)
            {
                _traineeCourseRepository.Add(traineeld);
                return RedirectToAction(nameof(Index));
            }
            return View(traineeld);
        }

        // GET: Trainees/Edit/5
        public IActionResult Edit(int? traineeId, int? courseId)
        {
             /* These gets there values from the indexVeiw @action towards edit naming,
                 Check it out !!! */

            ViewBag.TraineeID = new SelectList(_traineeRepository.GetAll(), "ID", "Name");
            ViewBag.CourseID = new SelectList(_courseRepository.GetAll(), "ID", "Topic");



            if (traineeId == null || courseId == null)
            {
                return NotFound();
            }

            var _traineeld = _traineeCourseRepository.GetById(traineeId.Value, courseId.Value);
            if (_traineeld == null)
            {
                return NotFound();
            }
            return View(_traineeld);
        }

        // POST: Trainees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int traineeId, int courseId, [Bind("TraineeID,CourseID,notes")] TraineeCourse xtraineeld)
        {

            /*  traineeId and courseId still have values because they took it from TraineeID and CourseID that have been
             *  sumbited in the save, 
                Appearantly the framework model binding is case-insensitive !!!!! 

                I tried changing traineeId to `traineeIdx` in the`index` view and in the both actions, 
                and it did not recive a value as it's completely different than TraineeID

            ---- Summary -----
            In this case, the `traineeId` and `courseId` values are being passed to the `POST` `Edit` action method through the `TraineeID` and `CourseID` select elements in the form. When the form is submitted, the selected values of these select elements will be passed to the action method along with any other data entered into the form.

            The names of these select elements (`TraineeID` and `CourseID`) match the names of the parameters in your action method (`traineeId` and `courseId`). The framework will automatically bind these values to their corresponding parameters in your action method when it receives a request.

            It's important to note that model binding in ASP.NET Core MVC is case-insensitive, so even though there is a difference in casing between your parameter names (`traineeId`, `courseId`) and your select element names (`TraineeID`, `CourseID`), they will still be correctly bound.

            */


            ViewBag.TraineeID = new SelectList(_traineeRepository.GetAll(), "ID", "Name");
            ViewBag.CourseID = new SelectList(_courseRepository.GetAll(), "ID", "Topic");

            var _traineeld = _traineeCourseRepository.GetById(xtraineeld.TraineeID, xtraineeld.CourseID);
            if (_traineeld != null)
            {
                ModelState.AddModelError("", "This trainee is already enrolled in this course.");
                return View(_traineeld);
            }


            if (traineeId != xtraineeld.TraineeID || courseId != xtraineeld.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _traineeCourseRepository.Update(xtraineeld);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeCourseExists(xtraineeld.TraineeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(xtraineeld);
        }


        // GET: Trainees/Delete/5
        public IActionResult Delete(int? traineeId, int? courseId)
        {
            if (traineeId == null || courseId == null)
            {
                return NotFound();
            }

            var traineeIdx = _traineeCourseRepository.GetById(traineeId.Value, courseId.Value);
            if (traineeIdx == null)
            {
                return NotFound();
            }

            return View(traineeIdx);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int traineeId, int courseId)
        {
            _traineeCourseRepository.Delete(traineeId, courseId);
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeCourseExists(int traineeId)
        {
            return _traineeCourseRepository.GetAll().Any(e => e.TraineeID == traineeId);
        }


    }
}
