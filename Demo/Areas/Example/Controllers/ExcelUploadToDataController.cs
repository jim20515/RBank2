using Demo.Areas.Example.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Example.Controllers
{
    public class ExcelUploadToDataController : Controller
    {
        // GET: Example/ExcelUploadToData
        public ActionResult Index()
        {
            List<ExcelData> dataList = new List<ExcelData>();
            return View(dataList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadData(FormCollection formCollection)
        {
            if (Request != null)
            {
                try
                {
                    HttpPostedFileBase file = Request.Files["UploadedFile"];
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                        List<ExcelData> dataList = new List<ExcelData>();

                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;

                            //開始 Excel 轉換為 Data 物件
                            DateTime now = DateTime.Now;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                var exceldata = new ExcelData();
                                exceldata.TestId = workSheet.Cells[rowIterator, 1].Value.ToString();
                                exceldata.TestName = workSheet.Cells[rowIterator, 2].Value.ToString();
                                exceldata.TestSex = workSheet.Cells[rowIterator, 3].Value.ToString();

                                dataList.Add(exceldata);
                            }

                        }

                        TempData["Msg"] = "更新成功";
                        return View("Index", dataList);
                    }
                }
                catch
                {

                    TempData["Msg"] = "更新失敗";
                }
            }
            return View();
        }
    }
}