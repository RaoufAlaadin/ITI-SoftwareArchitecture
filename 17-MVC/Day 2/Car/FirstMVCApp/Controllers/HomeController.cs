using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        /*  MVC Actions Rules.
         * 
         * 1- Within any controller, if you want to expose an Action using a likn, 
          it mus be a public function

        note: private methods cannot be accessed using a url.
        
         2- Return using the abstract class ActionResult, or be specific if u want
            ex:  viewResult

        Later on we will have scaffolded code, it's due to everything following a pattern, 
        This what makes it possible. 

        3- passing data from controller to view.

        // ViewData() => Dictionary object inside every Controller, Shared with views. 
        

        ****Dynamic vs Var
        The dynamic type is resolved at runtime and allows for late binding, 
        while the var type is resolved at compile-time and requires initialization.

        4- viewData and viewBag and used to store the data we imported from the database,
           So they can be shared with the view of the same name. 

        */

        /* {controller}/{action}/{id} => home/testfun => this will take us to the method. */
        public ActionResult testFun()
        {
            //return "Hello MVC world"; 

            #region long method, use View() instead as long as u follow naming convention.
            //ViewResult result = new ViewResult();
            //// The name of the view we want to show.
            //result.ViewName = "testFun"; 
            #endregion

            // It knows the `View name` based on the `Action name` , 3 lines in 1;
            // instead of creating the object...... naming it.......returning it. 

            //Method-1
            ViewData["msg"] = "Hello MVC World..";
            //Method-2 -(new) Viewbag => Wrapper for ViewData. 
            // `str` is just a random property we named. 
            ViewBag.str = "string from viewbag";

            return View();
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