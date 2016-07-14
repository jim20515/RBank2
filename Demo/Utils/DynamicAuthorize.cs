using Demo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo.Utils
{
    public class DynamicAuthorize : AuthorizeAttribute
    {
    //    class AccessItem
    //    {
    //        public string User { get; set; }
    //        public string Url { get; set; }
    //    }
    //    private static readonly List<AccessItem> _accessList = new List<AccessItem>()
    //{
    //    new AccessItem(){ User="usr1", Url="home/index" },
    //    new AccessItem(){ User="usr2", Url="home/index" },
    //    new AccessItem(){ User="acc",  Url="accounting/index" },
    //};

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                        filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (!skipAuthorization)
                base.OnAuthorization(filterContext);
            else
                return;

            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string url = Path.Combine(controllerName, actionName);

            //if user authenticated check if he is authorized
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                using (RBank2Entities db = new RBank2Entities())
                {

                    var cname = db.Account_ControllerName.FirstOrDefault(x => x.ControllerName.Equals(controllerName));
                    if (cname == null)
                        return;
                    
                    var user = filterContext.HttpContext.User;

                    if (cname.AspNetRoles.Count() == 0 || !UserInRoles(user, cname.AspNetRoles.Select(x => x.Name).ToList()))
                    {
                        filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary {
                        { "Controller", "Account" }, 
                        { "Action", "AccessDenied" }});
                    }
                    
                }
            }
        }

        private bool UserInRoles(IPrincipal user, List<string> roles)
        {
            foreach (var role in roles)
            {
                if (user.IsInRole(role))
                    return true;
            }

            return false;
        }
    }
}