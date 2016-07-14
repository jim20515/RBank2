using System.ComponentModel.DataAnnotations;

namespace Demo.Areas.Example.Models
{
    //1. 測試table schema
    //CREATE TABLE [dbo].[Departments] (
    //    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    //    [Title]  NVARCHAR (50) NOT NULL,
    //    [Status] BIT           NOT NULL,
    //    PRIMARY KEY CLUSTERED ([Id] ASC)
    //);


    //2. edmx的Model與metadata的namespace必須相同
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {
    }

    public class DepartmentMetaData
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "分類名稱")]
        public string Title { get; set; }

        [UIHint("BooleanButtonLabel")]
        [Display(Name = "狀態")]
        public bool Status { get; set; }
    }
}