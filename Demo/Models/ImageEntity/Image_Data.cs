namespace Demo.Models.ImageEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[Image.Data]")]
    public partial class Image_Data
    {
        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(100)]
        public string FileName { get; set; }

        [Required]
        public byte[] Data { get; set; }

        public bool IsDelete { get; set; }
    }
}
