using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon.MVC
{
    public class ContentResult : ActionResult
    {
        public ContentResult(string content)
        {
            Content = content; 
        }
    }
}
