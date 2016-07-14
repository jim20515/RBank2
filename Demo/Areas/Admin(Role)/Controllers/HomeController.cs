using Demo.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private DemoRolesEntities db = new DemoRolesEntities();

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SideBarItems()
        {
            //var q = db.Account_SideBarType.OrderBy(x => x.Type).ToList();
            var UserId = User.Identity.GetUserId();
            var q = (from u in db.AspNetUsers
                     from r in u.AspNetRoles
                     from c in r.Account_ControllerName
                     join s in db.Account_SideBarType on c.Type equals s.Type
                     where u.Id == UserId
                     orderby s.Type, c.Priority
                     select new SideBarViewModel
                     {
                         ControllerName = c.ControllerName,
                         ControllerTitle = c.Title,
                         ControllerPriority = c.Priority,
                         SideBarTypeTitle = s.Title
                     }).ToList();

            return View("~/Areas/Admin/Views/Shared/_Sidebar.cshtml", q);
        }
    }
}
