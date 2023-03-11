using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMVCApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /* ID is like an input parameter to the method we are going to 
             * create later. */

            #region My Custom Route => Write /test 
            /* Route table is generated, each record should have a unique name,
             That's why we write those names for RegisterRoutes to distingush. */
            routes.MapRoute(
                name: "MyNewRoute",
                /*This means if I write /test in the url, it should take me to the default parameters*/
                url: "test",
                defaults: new { controller = "Home", action = "about", id = UrlParameter.Optional }
            );

            #endregion

            #region Second Route Test
            
            routes.MapRoute(
                name: "MySecondRoute",
                /* I had to include all the variables if I include onee it seems. */
                url: "MVC/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );

            #endregion


            #region General Route -Leave it at the bottom.. or else "Error"
            routes.MapRoute(
                   name: "Default",
                   // name // page name // it's id (ignore)
                   url: "{controller}/{action}/{id}",
                   // This states that the ID pararmeter is optional.
                   // The default values are the ones shown when you first visit the website.
                   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               ); 
            #endregion

        }
    }
}
