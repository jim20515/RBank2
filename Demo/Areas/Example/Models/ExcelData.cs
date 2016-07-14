using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Areas.Example.Models
{
    // 接Excel資料的類別
    public class ExcelData
    {
        [Display(Name = "測試Id")]
        public string TestId { get; set; }

        [Display(Name = "測試名稱")]
        public string TestName { get; set; }

        [Display(Name = "測試性別")]
        public string TestSex { get; set; }
    }
}