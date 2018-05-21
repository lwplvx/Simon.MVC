using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simon.MVC.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //HttpContext.Current.Response.Write("Hello MVC");

            return Content("Hello Simon MVC");
        }
        public ActionResult Json()
        {
            return Json(new
            {
                Name = "Simon",
                Remark = "Json data test"
            });
        }

    }
}