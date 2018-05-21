using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon.MVC
{
    public abstract class ActionResult
    {
        public string Content { get; set; }
        public Dictionary<string, string> Headers { get; private set; } = new Dictionary<string, string>();

    }
}
