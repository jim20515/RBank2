using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class SettingController : Controller
    {
        // GET: Admin/Setting
        public ActionResult Index()
        {
            return View(new SettingService().List());
        }

        // POST: Admin/Setting/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Setting model)
        {
            new SettingService().Create(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public bool UpdateName(string pk, string value)
        {
            return new SettingService().SetName(pk, value);
        }

        [HttpPost]
        [ValidateInput(false)]
        public bool UpdateValue(string pk, string value) 
        {
            return new SettingService().SetValue(pk, value);
        }

        // GET: Admin/Setting/Delete
        public ActionResult Delete(string name)
        {
            new SettingService().Delete(name);
            return RedirectToAction("Index");
        }
    }
}