﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon.MVC
{
    //这个类主要定义约束
    public abstract class ControllerBase : IController
    { 
        public abstract void Execute(System.Web.Routing.RequestContext requestContext);
    }
}
