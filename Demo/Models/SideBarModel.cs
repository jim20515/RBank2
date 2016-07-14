using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class SideBarModel
    {
        public string TypeName { get; set; }
        public List<InnerSideBarModel> InnerSideBars { get; set; }
    }

    public class InnerSideBarModel
    {
        public string ControllerName { get; set; }
        public string ControllerTitle { get;set; }
        public int Priority { get; set; }
    }
}