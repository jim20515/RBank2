using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Areas.Admin.Models.SortableModal
{
    public class BaseSortableModal
    {
        public string FilePath { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
    }
}