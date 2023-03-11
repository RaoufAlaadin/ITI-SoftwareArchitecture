using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day4Demo.Controllers
{
    //[HandleError(View = "myErrorPage" , ExceptionType = typeof(DivideByZeroException))]
    [HandleError(View = "myErrorPage")]

    public class HomeController : Controller
    {
        public ActionResult testFun()
        {

            #region Error Method-1
            /*  try
              {
                  string msg = null;
                  ViewBag.msgLength = msgLength; // Error => run without debugging

                  return View();

              }
              catch
              {
                  return View("Error");
              }*/
            #endregion


            #region Error Method-2 => Filteration
           
                string msg = null;
                ViewBag.msgLength = msg.Length; // Error => run without debugging

                return View();

           
            
            #endregion


        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}