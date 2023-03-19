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
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: Courses
        public IActionResult Index()
        {
            var courses = _courseRepository.GetAll();
            return View(courses);
        }

        // GET: Courses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseRepository.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Topic,Grade")] Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Add(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseRepository.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Topic,Grade")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _courseRepository.Update(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_courseRepository.GetById(course.ID) != null)
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
            return View(course);
        }



        // GET: Courses/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseRepository.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course != null)
            {
                _courseRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        
    }
}
