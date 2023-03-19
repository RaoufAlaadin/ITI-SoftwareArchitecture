using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Client client)
        {
            if (ModelState.IsValid)
            {
                MainDBContext context = new MainDBContext();

                context.Clients.Add(client);

                context.SaveChanges();

                var userIdentiy = new ClaimsIdentity(new List<Claim>()
                {
                        /* ClaimsIdentity takes Claims and authentication type. */
                    new Claim("ClientName",client.ClientName),
                    new Claim("Password",client.Password),
                    new Claim("Address",client.Address),
                    new Claim("Mobile",client.Mobile),
                    new Claim("Email",client.Email)

                }, "AppCookie");


                // Gets Owin authentication manger, which is the middleware layer
                // responsible for the authentication process. 
                Request.GetOwinContext().Authentication.SignIn(userIdentiy);  

                // if the previous is true then 

                return RedirectToAction("Index","Home");   

            }


            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Client client)
        {
           
            
                MainDBContext context = new MainDBContext();

                var loggedUser = context.Clients.FirstOrDefault(
                     c => c.Email == client.Email && c.Password == client.Password) ;

                // This makes sure that we didn't press login by mistake. 
                if (loggedUser != null)
                {
                        var singInIdentity = new ClaimsIdentity(new List<Claim>()
                    {
                            /* ClaimsIdentity takes Claims and authentication type. */
                        new Claim("Email",client.Email),
                        new Claim("Password",client.Password)

                    }, "AppCookie");

                    Request.GetOwinContext().Authentication.SignIn(singInIdentity);

                    return RedirectToAction("Index", "Home");


                }
                else{
                    ModelState.AddModelError("Email", "Credentials are not found");

               
                    return View();

                }

            

        }

        public ActionResult Logout()
        {

            // Destroy cookie for that user using the OWIN context manger

            Request.GetOwinContext().Authentication.SignOut("AppCookie");

            return RedirectToAction("Login");
        }
    }
}