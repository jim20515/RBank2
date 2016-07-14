using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private RBank2Entities db = new RBank2Entities();

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
            var menu = new List<SideBarModel>();

            if (User.Identity.IsAuthenticated)
            {
                var types = db.Account_SideBarType.ToList();
                var cNames = db.vwUserPermission.Where(x => x.UserName.Equals(User.Identity.Name));

                foreach (var p in types)
                {
                    if (cNames.Where(x => x.Type == p.Type).Count() == 0)
                        continue;

                    var temp = new SideBarModel();
                    temp.TypeName = p.Title;
                    temp.InnerSideBars = (from q in cNames
                                          where q.Type == p.Type
                                          select new InnerSideBarModel
                                          {
                                              ControllerTitle = q.ControllerTitle,
                                              ControllerName = q.ControllerName,
                                              Priority = q.Priority
                                          }).ToList();

                    menu.Add(temp);
                }

            }

            return View("~/Views/Shared/_Sidebar.cshtml", menu);
        }
    }
}
