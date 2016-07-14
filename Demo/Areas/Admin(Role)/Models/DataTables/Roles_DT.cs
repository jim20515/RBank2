using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Areas.Admin.Models.DataTables
{
    public class Roles_DT
    {
        [DataTables(DisplayName = "帳號識別碼", Searchable = true)]
        public string Id { get; set; }

        [DataTables(DisplayName = "角色名稱", Searchable = true)]
        public string Name { get; set; }

        [DataTables(DisplayName = "管理功能", Searchable = true)]
        public List<Account_ControllerName> Account_ControllerName { get; set; }
    }
}