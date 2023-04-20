using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SinglaRDemoReaouf.Controllers
{
    public class ChatroomController : Controller
    {
        // GET: ChatroomController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ChatroomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChatroomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatroomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatroomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChatroomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatroomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChatroomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
