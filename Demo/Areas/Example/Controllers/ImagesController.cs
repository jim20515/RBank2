using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Example.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Example/Images
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                //The resizing settings can specify any of 30 commands.. See http://imageresizing.net for details.
                //Destination paths can have variables like <guid> and <ext>, or 
                //even a santizied version of the original filename, like <filename:A-Za-z0-9>
                ImageJob job = new ImageJob(file, "~/Uploads/Resize/<guid>.<ext>", new Instructions("mode=max;format=jpg;width=2000;height=2000;"));
                job.CreateParentDirectory = true;
                //job.AddFileExtension = true;
                job.Build();
                //string fileName = Path.GetFileName(job.FinalPath);
                //ViewBag.ImageUrl = Url.Content("~/Uploads/Resize/" + fileName);
                //ViewBag.FileName = fileName;
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Uploads(IEnumerable<HttpPostedFileBase> files)
        {
            //Loop through each uploaded file
            foreach (var file in files)
            {
                if (file.ContentLength <= 0) continue; //Skip unused file controls.

                //The resizing settings can specify any of 30 commands.. See http://imageresizing.net for details.
                //Destination paths can have variables like <guid> and <ext>, or 
                //even a santizied version of the original filename, like <filename:A-Za-z0-9>
                ImageJob job = new ImageJob(file, "~/Uploads/Resize/<guid>.<ext>", new Instructions("width=2000;height=2000;format=jpg;mode=max;"));
                job.CreateParentDirectory = true; //Auto-create the uploads directory.
                job.Build();
            }
            return View("Index");
        }
    }
}