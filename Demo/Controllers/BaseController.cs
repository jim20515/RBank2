using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace Demo.Controllers
{
    public class BaseController : Controller
    {
        private ILog logger;

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    logger.InfoFormat("Executing Request: {0}\t Controller: {1}, Action: {2}", 
        //        filterContext.RequestContext.HttpContext.Request.Url, 
        //        filterContext.RouteData.Values["controller"], 
        //        filterContext.RouteData.Values["action"]);
        //    base.OnActionExecuting(filterContext);
        //}

        protected override void OnException(ExceptionContext filterContext)
        {
            //Log error
            logger = log4net.LogManager.GetLogger(filterContext.Controller.ToString());
            logger.Error(filterContext.Exception.Message, filterContext.Exception);

            //If the request is AJAX return JSON else redirect user to Error view.
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                //Return JSON
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { error = true, message = "Sorry, an error occurred while processing your request." }
                };
            }
            else
            {
                // 正式環境 Redirect to 首頁
                #if !DEBUG
                //Redirect user to error page
                filterContext.ExceptionHandled = true;
                filterContext.Result = this.RedirectToAction("Index", "Home");
                #endif
            }

            base.OnException(filterContext);

        }
    }
}