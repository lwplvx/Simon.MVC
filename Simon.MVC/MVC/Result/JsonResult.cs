using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon.MVC
{
    public class JsonResult : ActionResult
    {
        public JsonResult()
        {
            Headers.Add("Content-Type", " application/json; charset=utf-8");
        }
    }
}
