using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(WebApplication1.Startup1))]

namespace WebApplication1
{
    public class Startup1
    {
            /* We come into this file after Global.asax to check the authentication.*/
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            /* We need cookie name and login path
             login path: that we get re-directed to when logging out or when invalid login credintials
           */

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            {
                AuthenticationType = "AppCookie",
                LoginPath = new PathString("/Account/Login")

            });

        }
    }
}
