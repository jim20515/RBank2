using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Demo.Models.Service
{
    public class HtmlEditorService : IDisposable
    {
        private HtmlDocument _doc = new HtmlDocument();
        private DBSaveImageService _service;

        public HtmlEditorService(string html, DBSaveImageService service)
        {
            _doc.LoadHtml(html);
            _service = service;
        }

        /// <summary>
        /// 儲存HtmlDocument中的圖片進資料庫(使用FileMan加入的才會寫入資料庫)
        /// </summary>
        /// <param name="server"></param>
        public void SaveImgIntoDb(HttpServerUtilityBase server)
        {
            var Nodes = _doc.DocumentNode.SelectNodes("//img[@src]");
            if (Nodes != null)
                //取得所有img tag中的src字串
                foreach (var item in Nodes)
                {
                    //判斷是否為虛擬路徑
                    if (Path.IsPathRooted(item.Attributes["src"].Value))
                    {
                        //判斷檔案是否存在
                        if (File.Exists(server.MapPath(item.Attributes["src"].Value)))
                        {
                            item.Attributes["src"].Value = _service.AddImageData(server.MapPath(item.Attributes["src"].Value));
                        }
                    }
                }
        }

        /// <summary>
        /// 比較新的Html與舊的Html中的Img連結
        /// 並且更新資料庫內的圖片
        /// </summary>
        /// <param name="server"></param>
        public void UpdateImageIntoDb(HttpServerUtilityBase server, string oldHtml)
        {
            HtmlDocument _old = new HtmlDocument();
            _old.LoadHtml(oldHtml);
            //先取得新Hmlt中圖片list
            var new_Src = _doc.DocumentNode.SelectNodes("//img[@src]") != null ? _doc.DocumentNode.SelectNodes("//img[@src]").Select(x => x.Attributes["src"].Value) : new List<string>();
            //在取得舊Hmlt中圖片list
            var old_Src = _old.DocumentNode.SelectNodes("//img[@src]") != null ? _old.DocumentNode.SelectNodes("//img[@src]").Select(x => x.Attributes["src"].Value) : new List<string>();
            //作交集
            var both = new_Src.Intersect(old_Src);
            //如果新Hmlt中有未存檔的圖片=>IntoDb
            //新舊交集 = >Do Nothing
            //舊的Html有多的圖=> Remove

            //也就是old_Src與交集的差集是我們要刪除的檔案
            var delete = old_Src.Except(both);
            foreach (var src in delete)
            {
                DeleteImage(src);
            }
            //新圖片存檔的工作交給SaveImgIntoDb處理
            SaveImgIntoDb(server);
        }

        /// <summary>
        /// 從資料庫中刪除HtmlDocument的圖片(當Img的src連結為"/Image/{Guid}才會刪除")
        /// </summary>
        public void DeleteImgInDb()
        {
            var Nodes = _doc.DocumentNode.SelectNodes("//img[@src]");
            if (Nodes != null)
                foreach (var item in Nodes)//select only those img that have a src attribute..ahh not required to do 
                {
                    DeleteImage(item.Attributes["src"].Value);
                }
        }

        /// <summary>
        /// 取得圖片路徑修改過的html
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            return _doc.DocumentNode.OuterHtml;
        }

        private void DeleteImage(string src)
        {
            if (src.StartsWith("/Image/"))
            {
                Guid guid;
                if (Guid.TryParse(src.Split('/').LastOrDefault(), out guid))
                {
                    _service.SetDeleteImageData(guid);
                }
            }

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
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。
                _doc = null;
                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~HtmlEditorService() {
        //   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}