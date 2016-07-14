using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Admin.Models
{
    [MetadataType(typeof(AspNetUsersMetadata))]
    public partial class AspNetUsers
    {
        [Display(Name = "角色")]
        public string Roles { get; set; }

        public class AspNetUsersMetadata
        {
            [Display(Name = "流水號")]
            public int Id { get; set; }

            [Display(Name = "使用者名稱")]
            public int UserName { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "建立時間")]
            public string CreateDate { get; set; }

            [Required]
            [Display(Name = "狀態")]
            public bool Status { get; set; }

            [Display(Name = "系統角色")]
            public string AspNetRoles { get; set; }
        }
    }

    [MetadataType(typeof(AspNetRolesMetadata))]
    public partial class AspNetRoles
    {
        public class AspNetRolesMetadata
        {
            [Required]
            [Display(Name = "帳號識別碼")]
            public string Id { get; set; }

            [Required]
            [Display(Name = "使用者名稱")]
            public string Name { get; set; }

            [Display(Name = "管理功能")]
            public List<Account_ControllerName> Account_ControllerName { get; set; }
        }
    }
}

