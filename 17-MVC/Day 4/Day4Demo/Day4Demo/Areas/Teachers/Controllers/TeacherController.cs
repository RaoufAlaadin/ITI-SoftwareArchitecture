using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day4Demo.Areas.Teachers.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teachers/Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teachers/Teacher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Teachers/Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Teacher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teachers/Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teachers/Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teachers/Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teachers/Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
