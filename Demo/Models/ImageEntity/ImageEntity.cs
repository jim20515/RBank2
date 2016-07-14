namespace Demo.Models.ImageEntity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ImageEntity : DbContext
    {
        public ImageEntity()
            : base("name=ImageEntity")
        {
        }

        public virtual DbSet<Image_Data> Image_Data { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
