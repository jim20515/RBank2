using Demo.Models;
using Demo.Areas.Example.Models;
using Demo.Models.ImageEntity;
using System;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class FilesController : Controller
    {
        // GET: Image
        public ActionResult Image(string _id)
        {
            using (ImageEntity db = new ImageEntity())
            {
                Guid guid;

                if (!Guid.TryParse(_id, out guid))
                {
                    return HttpNotFound();
                }

                var imageData = db.Image_Data.Find(guid);
                if (imageData == null || imageData.IsDelete)
                {
                    return HttpNotFound();
                }
                return File(imageData.Data, MimeTypes.MimeTypeMap.GetMimeType(System.IO.Path.GetExtension(imageData.FileName)));
            }
        }
        #region
        //public string TryInsertFileIntoDB(string filepath)
        //{
        //    if (System.IO.File.Exists(filepath))
        //    {
        //        using (Entities db = new Entities())
        //        {
        //            //if (Utils.GlobalFuns.SaveFileIntoDB(filepath, db) != null)
        //            //{
        //            //    return "Success";
        //            //}
        //            return Utils.GlobalFuns.SaveFileIntoDB(filepath, db).ToString();
        //        }
        //    }
        //    return "fail";
        //}

        //public string TryUpdateFileInDB(string id, string filepath)
        //{
        //    if (System.IO.File.Exists(filepath))
        //    {
        //        using (Entities db = new Entities())
        //        {
        //            if (Utils.GlobalFuns.UpdateFileInDB(Guid.Parse(id), filepath, db))
        //            {
        //                return "Success";
        //            }
        //        }
        //    }
        //    return "fail";
        //}

        //public string TryDeleteFileInDB(string id)
        //{
        //    using (Entities db = new Entities())
        //    {
        //        return Utils.GlobalFuns.DeleteFileInDB(Guid.Parse(id), db).ToString();
        //    }
        //}

        //public string TryInsertHtmlImgIntoDB()
        //{
        //    //會回傳圖片 並且圖片已經存到資料庫中
        //    using (Entities db = new Entities())
        //    {
        //        string html = "<p><img src=\"/Uploads/Documents/31609.jpg\" alt=\"\" width=\"528\" height=\"400\" /></p>";
        //        //string html = "<p><img src=\"https://pixabay.com/static/uploads/photo/2015/11/12/10/24/explosion-1039943_960_720.jpg\" alt=\"\" width=\"528\" height=\"400\" /></p>";
        //        HtmlEditorService service = new HtmlEditorService(html);
        //        service.SaveImgIntoDb(Server, db);
        //        return service.GetHtml();
        //    }
        //}

        //public string TryDeleteHtmlImgInDB()
        //{
        //    //圖片為404
        //    using (Entities db = new Entities())
        //    {
        //        string html = "<p><img src=\"/Image/82bff2b4-355d-47e1-9a15-0c4497450d06\" alt=\"\" width=\"528\" height=\"400\"></p>";
        //        HtmlEditorService service = new HtmlEditorService(html);
        //        service.DeleteImgInDb(db);
        //        return service.GetHtml();
        //    }
        //}

        //USE[DB_NAME]
        //CREATE TABLE[dbo].[Image.Data] (
        //[Guid] [uniqueidentifier] NOT NULL,
        //[FileName] [nvarchar](100) NOT NULL,
        //[Data] [varbinary](max) NOT NULL,
        //[IsDelete] [bit] NOT NULL
        // CONSTRAINT[PK_Image.Data] PRIMARY KEY CLUSTERED([Guid] ASC)
        //);
        #endregion
    }
}