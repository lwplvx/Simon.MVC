using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Simon.MVC
{
    public abstract class Controller : ControllerBase, IDisposable
    {
        public override void Execute(System.Web.Routing.RequestContext requestContext)
        {
            //反射得到Action方法
            Type type = this.GetType();
            string actionName = requestContext.RouteData.GetRequiredString("action");
            System.Reflection.MethodInfo mi = type.GetMethod(actionName);
            // 匹配一下首字母大写
            if (mi == null)
            {
                actionName = actionName.Substring(0, 1).ToUpper() + actionName.Substring(1);
                mi = type.GetMethod(actionName);
            }

            //执行该Action方法
            var result = mi.Invoke(this, new object[] { });//调用方法
            if (result is ActionResult actionResult)
            {
                foreach (var item in actionResult.Headers)
                {
                    HttpContext.Current.Response.AddHeader(item.Key, item.Value);
                }

                HttpContext.Current.Response.Write(actionResult.Content);
            }


        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        protected ContentResult Content(string content)
        {
            return new ContentResult(content);
        }

        protected JsonResult Json(Object obj)
        {
            return new JsonResult()
            {
                Content = JObject.FromObject(obj).ToString(),
            };
        }
    }

}