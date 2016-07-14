using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Example.Models
{
    [MetadataType(typeof(SampleMetaData))]
    public partial class Sample
    {
        [AllowHtml]
        [Display(Name = "相簿管理")]
        public string SM_JSON { get; set; }
    }

    public class SampleMetaData
    {
        //[AllowHtml]
        [UIHint("Editor")]
        public string Address { get; set; }
    }

}