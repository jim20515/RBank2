using Mvc.JQuery.DataTables;

namespace Demo.Areas.Admin.Models.DataTables
{
    public class Account_DT
    {
        [DataTables(DisplayName = "流水號", Searchable = true, Visible = false)]
        public string Id { get; set; }

        [DataTables(DisplayName = "使用者名稱", Searchable = true)]
        public string UserName { get; set; }

        [DataTables(DisplayName = "Email", Searchable = true)]
        public string Email { get; set; }

        [DataTables(DisplayName = "建立時間", Searchable = true)]
        public System.DateTime CreateDate { get; set; }

        [DataTables(DisplayName = "狀態", Searchable = true, MRenderFunction = "BooleanButtonLabel")]
        public string Status { get; set; }

        [DataTables(DisplayName = "系統角色", Searchable = true)]
        public string AspNetRoles { get; set; }
    }
}