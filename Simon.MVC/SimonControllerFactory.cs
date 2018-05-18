﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Simon.MVC
{
    public class SimonControllerFactory : IControllerFactory
    {
        #region Public
        //通过当前的请求上下文和控制器名称得到控制器的对象
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException("requestContext");
            }

            if (string.IsNullOrEmpty(controllerName))
            {
                throw new ArgumentException("controllerName");
            }
            //得到当前的控制类型
            Type controllerType = GetControllerType(requestContext, controllerName);
            if (controllerType == null)
            {
                return null;
            }
            //得到控制器对象
            IController controller = GetControllerInstance(requestContext, controllerType);
            return controller;
        }

        //释放控制器对象
        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
        #endregion

        #region Privates
        //得到当前请求的控制器实例
        private IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            var oRes = Activator.CreateInstance(controllerType) as IController;
            return oRes;
        }

        //得到当前请求的控制器类型
        private Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            //从路由配置信息里面读取命名空间和程序集
            requestContext.RouteData.Values.TryGetValue("namespaces", out object routeNamespaces);
            requestContext.RouteData.Values.TryGetValue("assembly", out object routeAssembly);

            //通过反射得到控制器的类型
            var type = Assembly.Load(routeAssembly.ToString()).GetType(routeNamespaces.ToString() + "." + controllerName + "Controller");

            return type;
        }
        #endregion
    }
}
