using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Areas.Admin.Models;
using Demo.Utils;
using Mvc.JQuery.DataTables;
using Demo.Areas.Admin.Models.DataTables;

namespace Demo.Areas.Admin.Controllers
{
    [DynamicAuthorize]
    public class RolesController : Controller
    {
        private DemoRolesEntities db = new DemoRolesEntities();

        // GET: Admin/Roles
        public ActionResult Index()
        {
            return View(db.AspNetRoles.Include(x => x.Account_ControllerName).ToList());
        }

        // GET: Admin/Roles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRoles aspNetRoles = db.AspNetRoles.Find(id);
            if (aspNetRoles == null)
            {
                return HttpNotFound();
            }
            return View(aspNetRoles);
        }

        // GET: Admin/Roles/Create
        public ActionResult Create()
        {
            ViewBag.RoleItems = this.RoleSelectListItems();

            return View();
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AspNetRoles aspNetRoles, string[] ControllerNames)
        {
            var selectedControllerNames = ControllerNames;

            if (ModelState.IsValid)
            {
                db.AspNetRoles.Add(aspNetRoles);

                if (selectedControllerNames.Count() > 0)
                {
                    foreach (var id in selectedControllerNames)
                    {
                        Account_ControllerName name = db.Account_ControllerName.FirstOrDefault(x => x.ControllerName.ToString().Equals(id));

                        aspNetRoles.Account_ControllerName.Add(name);
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.RoleItems = this.RoleSelectListItems(string.Join(",", selectedControllerNames));
            return View(aspNetRoles);
        }

        // GET: Admin/Roles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRoles aspNetRoles = db.AspNetRoles.Find(id);
            if (aspNetRoles == null)
            {
                return HttpNotFound();
            }

            var selectedControllerNames = aspNetRoles.Account_ControllerName.Select(x => x.ControllerName);

            ViewBag.RoleItems = this.RoleSelectListItems(string.Join(",", selectedControllerNames));
            return View(aspNetRoles);
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AspNetRoles aspNetRoles, string[] ControllerNames)
        {
            var selectedControllerNames = ControllerNames;

            if (ModelState.IsValid)
            {

                db.Entry(aspNetRoles).State = EntityState.Modified;

                if (selectedControllerNames.Count() > 0)
                {

                    //first delete db data
                    var entity = (from p in db.AspNetRoles.Include(x => x.Account_ControllerName)
                                  where p.Id == aspNetRoles.Id
                                  select p).FirstOrDefault();

                    if (entity.Account_ControllerName.Count > 0)
                        entity.Account_ControllerName.ToList().ForEach(x => entity.Account_ControllerName.Remove(x));

                    foreach (var id in selectedControllerNames)
                    {
                        Account_ControllerName name = db.Account_ControllerName.FirstOrDefault(x => x.ControllerName.ToString().Equals(id));

                        aspNetRoles.Account_ControllerName.Add(name);
                    }
                }

                db.SaveChanges();

				if (Request.Form["ActionSave"] == "SaveAndEdit")
                {
                    return View(aspNetRoles);
                }
                return RedirectToAction("Index");
            }

            ViewBag.RoleItems = this.RoleSelectListItems(string.Join(",", selectedControllerNames));
            return View(aspNetRoles);
        }

        // GET: Admin/Roles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRoles aspNetRoles = db.AspNetRoles.Find(id);
            if (aspNetRoles == null)
            {
                return HttpNotFound();
            }

            return View(aspNetRoles);
        }

        // POST: Admin/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetRoles aspNetRoles = db.AspNetRoles.Find(id);

            //first delete db data
            var entity = (from p in db.AspNetRoles.Include("Account_ControllerName").Include("AspNetUsers")
                          where p.Id == aspNetRoles.Id
                          select p).FirstOrDefault();

            if (entity.AspNetUsers.Count > 0)
            {
                TempData["message"] = "無法刪除，請到[帳號管理]中把相關人員的角色轉移再進行刪除";
                return RedirectToAction("Delete");
            }

            if (entity.Account_ControllerName.Count > 0)
                entity.Account_ControllerName.ToList().ForEach(x => entity.Account_ControllerName.Remove(x));

            db.AspNetRoles.Remove(aspNetRoles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private List<SelectListItem> RoleSelectListItems(string selected = "")
        {
            var names = db.Account_ControllerName.OrderBy(x => x.Type).ThenBy(x => x.Priority).ToList();
            var items = new List<SelectListItem>();

            var selectedNames = string.IsNullOrWhiteSpace(selected)
                ? null
                : selected.Split(',');

            foreach (var c in names)
            {
                items.Add(item: new SelectListItem()
                {
                    Value = c.ControllerName.ToString(),
                    Text = c.Title,
                    Selected = selectedNames == null
                        ? false
                        : selectedNames.Contains(c.ControllerName.ToString())
                });
            }

            return items;
        }

        /// <summary>
        /// 提供 DataTables Server-Side 抓取資料
        /// 需要建立一個 AspNetUsers_DT.cs
        /// 請參考 /Areas/Admin/Models/DataTables/Sample_DT.css
        /// </summary>
        /// <param name="dataTableParam"></param>
        /// <returns></returns>
        public DataTablesResult<Roles_DT> GetServerData(DataTablesParam dataTableParam)
        {
            IQueryable<Roles_DT> rs = db.AspNetRoles.Include(x => x.Account_ControllerName).Select(p => new Roles_DT { Id = p.Id, Name = p.Name, Account_ControllerName = p.Account_ControllerName.ToList() });

            return DataTablesResult.Create(rs, dataTableParam, x => new
            {
                Id = x.Id,
                Name = x.Name,
                Account_ControllerName = string.Join(", ", x.Account_ControllerName.Select(z => z.Title).ToArray())
            });
        }
    }
}
