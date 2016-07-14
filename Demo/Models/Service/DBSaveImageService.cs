using Demo.Models.ImageEntity;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace Demo.Models.Service
{
    public class DBSaveImageService : IDisposable
    {
        private Demo.Models.ImageEntity.ImageEntity _db;
        public DBSaveImageService()
        {
            _db = new Demo.Models.ImageEntity.ImageEntity();
            #region try check db table is exist
            //if (!_db.Image_Data.Any())
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append(string.Format("USE[{0}] ", db.Database.Connection.Database));
            //    sb.Append("CREATE TABLE[dbo].[Image.Data] ( ");
            //    sb.Append("[Guid] [uniqueidentifier] NOT NULL, ");
            //    sb.Append("[FileName] [nvarchar](100) NOT NULL, ");
            //    sb.Append("[Data] [varbinary](max) NOT NULL, ");
            //    sb.Append("[IsDelete] [bit] NOT NULL ");
            //    sb.Append("CONSTRAINT[PK_Image.Data] PRIMARY KEY CLUSTERED([Guid] ASC) ");
            //    sb.Append("); ");
            //    db.Database.ExecuteSqlCommand(sb.ToString());
            //}
            #endregion
        }

        /// <summary>
        /// 將檔案存入資料庫
        /// </summary>
        /// <param name="filePath">檔案路徑</param>
        /// <returns>Image Url</returns>
        public string AddImageData(Guid guid, string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            _db.Entry(new Image_Data()
            {
                Guid = guid,
                Data = File.ReadAllBytes(filePath),
                FileName = Path.GetFileName(filePath),
                IsDelete = false
            }).State = EntityState.Added;

            return string.Format("/Image/{0}", guid.ToString());
        }

        /// <summary>
        /// 將檔案存入資料庫
        /// </summary>
        /// <param name="filePath">檔案路徑</param>
        /// <returns>Image Url</returns>
        public string AddImageData(string filePath)
        {
            return AddImageData(Guid.NewGuid(), filePath);
        }

        /// <summary>
        /// 跟新Image
        /// </summary>
        /// <param name="img">圖片實體</param>
        public void UpdateImageData(Image_Data img)
        {
            if (_db.Image_Data.Any(x => x.Guid == img.Guid))
                _db.Entry(img).State = EntityState.Modified;
            else
                _db.Entry(img).State = EntityState.Added;
        }

        /// <summary>
        /// 將圖片的IsDelete = True
        /// </summary>
        /// <param name="img">圖片Guid</param>
        public void SetDeleteImageData(Guid guid)
        {
            var img = _db.Image_Data.Find(guid);
            if (img != null)
                img.IsDelete = true;
            //_db.Entry(img).State = EntityState.Modified;
        }

        /// <summary>
        /// 移除圖片
        /// </summary>
        /// <param name="img">圖片實體</param>
        public void RemoveImageData(Guid guid)
        {
            var image = _db.Image_Data.Find(guid);
            if (image != null)
                _db.Entry(image).State = EntityState.Deleted;
        }

        /// <summary>
        /// DB SaveChanges
        /// </summary>
        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public DbSet<Demo.Models.ImageEntity.Image_Data> GetImage_DataEntity()
        {
            return _db.Image_Data;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置 Managed 狀態 (Managed 物件)。
                    _db.Dispose();
                }
                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。
                disposedValue = true;
            }
        }

        //// TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        //~DBSaveImageService()
        //{
        //    // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //    Dispose(false);
        //}

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            GC.SuppressFinalize(this);
        }
        #endregion
    }
    //public class Image_Data
    //{
    //    public Guid Guid { get; set; }
    //    public string FileName { get; set; }
    //    public byte[] Data { get; set; }
    //    public bool IsDelete { get; set; }
    //}
}