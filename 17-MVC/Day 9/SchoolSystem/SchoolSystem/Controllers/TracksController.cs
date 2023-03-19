using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class TracksController : Controller
    {
        private readonly ITrackRepository _trackRepository;

        public TracksController(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        // GET: Courses
        public IActionResult Index()
        {
            var courses = _trackRepository.GetAll();
            return View(courses);
        }

        // GET: Courses/Details/5
        public IActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var course = _trackRepository.GetById(ID.Value);
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
        public IActionResult Create([Bind("Name,Description")] Track track)
        {

            //[Bind("Name,Description")]

            if (!ModelState.IsValid)
            {
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }


            if (ModelState.IsValid)
            {
                _trackRepository.Add(track);
                return RedirectToAction("Index");
            }

            /*   Name: SD
       Description: donet study*/
            return View(track);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _trackRepository.GetById(id.Value);
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
        public async Task<IActionResult> Edit(int ID, [Bind("ID,Name,Description")] Track track)
        {
            if (ID != track.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _trackRepository.Update(track);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_trackRepository.GetById(track.ID) != null)
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
            return View(track);
        }



        // GET: Courses/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _trackRepository.GetById(id.Value);
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
            var course = _trackRepository.GetById(id);
            if (course != null)
            {
                _trackRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        }
    }
