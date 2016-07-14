using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Demo.Areas.Example.Models
{
    //1. 測試table schema
    //CREATE TABLE [dbo].[Employees] (
    //    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    //    [Name]         NVARCHAR (50)  NULL,
    //    [Introduce]    NVARCHAR (MAX) NULL,
    //    [Age]          INT            NULL,
    //    [LogoPath]     NVARCHAR (50)  NULL,
    //    [StartDate]    DATETIME       NULL,
    //    [EndDate]      DATETIME       NULL,
    //    [EnrollDate]   DATETIME       NULL,
    //    [Status]       BIT            NOT NULL,
    //    [DepartmentId] INT            NOT NULL,
    //    PRIMARY KEY CLUSTERED ([Id] ASC),
    //    CONSTRAINT [FK_Employees_Departments] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([Id])
    //);

    //2. edmx的Model與metadata的namespace必須相同
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
        [Display(Name = "相簿管理")]
        public string SM_JSON { get; set; }
    }

    public class EmployeeMetaData
    {
        public int Id { get; set; }

        [Display(Name = "員工姓名")]
        public string Name { get; set; }

        [Required]
        [UIHint("Color")]
        [Display(Name = "自我介紹")]
        public string Introduce { get; set; }

        [Display(Name = "年齡")]
        public Nullable<int> Age { get; set; }

        [UIHint("PreviewImage")]
        [Display(Name = "大頭照")]
        public string LogoPath { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "開始時間")]
        public Nullable<System.DateTime> StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "結束時間")]
        public Nullable<System.DateTime> EndDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "註冊時間")]
        public Nullable<System.DateTime> EnrollDate { get; set; }

        [UIHint("BooleanButtonLabel")]
        [Display(Name = "狀態")]
        public bool Status { get; set; }

        [Display(Name = "部門名稱")]
        public int DepartmentId { get; set; }
    }
}