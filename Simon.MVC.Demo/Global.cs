using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Simon.MVC.Demo
{
    public class Global : System.Web.HttpApplication
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
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }
    }
}