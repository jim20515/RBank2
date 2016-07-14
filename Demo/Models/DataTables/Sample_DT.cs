using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Mvc.JQuery.DataTables;

namespace Demo.Models.DataTables
{
    public class Sample_DT
    {
        public int SampleID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> Birth { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public int Priority { get; set; }
    }
}


// 參考範例
// https://github.com/mcintyre321/mvc.jquery.datatables/blob/master/Mvc.JQuery.Datatables.Example/Controllers/HomeController.cs
//public class UserView
//{

//    [DataTables(DisplayName = "Name", DisplayNameResourceType = typeof(UserViewResource), MRenderFunction = "encloseInEmTag")]
//    public string Name { get; set; }

//    [DataTables(SortDirection = SortDirection.Ascending, Order = 0)]
//    public int Id { get; set; }

//    [DataTables(DisplayName = "E-Mail", Searchable = true)]
//    public string Email { get; set; }

//    [DataTables(Sortable = false, Width = "70px")]
//    public bool IsAdmin { get; set; }

//    [DataTables(Visible = false)]
//    public bool AHiddenColumn { get; set; }


//    [DataTables(Visible = false)]
//    public decimal Salary { get; set; }

//    public string Position { get; set; }

//    [DataTablesFilter(DataTablesFilterType.DateTimeRange)]
//    [DefaultToStartOf2014]
//    public DateTime? Hired { get; set; }

//    public Numbers Number { get; set; }

//    [DataTablesExclude]
//    public string ThisColumnIsExcluded { get { return "asdf"; } }

//    [DataTables(Sortable = false, Searchable = false)]
//    [DataTablesFilter(DataTablesFilterType.None)]
//    public string Thumb { get; set; }
//}

//public class DefaultToStartOf2014Attribute : DataTablesAttributeBase
//{
//    public override void ApplyTo(ColDef colDef, PropertyInfo pi)
//    {
//        colDef.SearchCols = colDef.SearchCols ?? new JObject();
//        colDef.SearchCols["sSearch"] = new DateTime(2014, 1, 1).ToString("g") + "~" + DateTimeOffset.Now.Date.AddDays(1).ToString("g");
//    }
//}