using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Example.Controllers
{
    public class FormsController : Controller
    {
        // GET: Example/Forms
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Datepicker()
        {
            return View();
        }

        public ActionResult Select()
        {
            return View();
        }
    }
}