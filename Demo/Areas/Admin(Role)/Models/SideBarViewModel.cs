using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Areas.Admin.Models
{
    public class SideBarViewModel
    {
        public string ControllerName { get; set; }
        public string ControllerTitle { get; set; }
        public int ControllerPriority { get; set; }
        public string SideBarTypeTitle { get; set; }
    }
}