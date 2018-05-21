using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Simon.MVC.Demo
{
    public class Global1 : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add("Default",
               new Route("{controller}/{action}/{id}",
               new RouteValueDictionary(new
               {
                   controller = "Home",
                   action = "Index",
                   id = "",
                   namespaces = "Simon.MVC.Demo.Controllers",
                   assembly = "Simon.MVC.Demo"
               }), new Simon.MVC.MvcRouteHandler()));

            ;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}