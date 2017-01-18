using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using System.Security.Principal;

namespace OpenLayersWebAPI.ActionFilters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string user = WindowsIdentity.GetCurrent().Name.ToString();
              Logger.Logger.LogInfo("Request from: " + user + "\nRequest Parameters: " + filterContext.ActionParameters.Keys);
        }
    }
}