using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Models.ImageEntity;
using System.IO;

namespace Demo.Models.Service.Tests
{
    [TestClass()]
    public class DBSaveImageServiceTests
    {
        [TestMethod()]
        public void DBSaveImageServiceTest()
        {
            try
            {
                using (DBSaveImageService service = new DBSaveImageService())
                {
                    
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void AddImageDataTest()
        {
            try
            {
                using (DBSaveImageService service = new DBSaveImageService())
                {
                    string path = "C:\\Users\\WhatsMedia\\Downloads\\31609.jpg";
                    var url = service.AddImageData(path);

                    var url_2 = service.AddImageData(Guid.Parse("c07dc6e3-001d-4071-a3a7-40745b05087d"),path);

                    service.SaveChanges();
                    Assert.IsFalse(string.IsNullOrEmpty(url));
                    Assert.IsFalse(string.IsNullOrEmpty(url_2));
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void UpdateImageDataTest()
        {
            try
            {
                using (DBSaveImageService service = new DBSaveImageService())
                {
                    string path = "C:\\Users\\WhatsMedia\\Downloads\\1462635426389_4.jpg";
                    service.UpdateImageData(new Image_Data()
                    {
                        Guid = Guid.Parse("c07dc6e3-001d-4071-a3a7-40745b05087d"),
                        Data = File.ReadAllBytes(path),
                        FileName = Path.GetFileName(path),
                        IsDelete = true
                    });
                    service.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void SetDeleteImageDataTest()
        {
            try
            {
                using (DBSaveImageService service = new DBSaveImageService())
                {
                    service.SetDeleteImageData(Guid.Parse("c07dc6e3-001d-4071-a3a7-40745b05087d"));
                    service.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void RemoveImageDataTest()
        {
            try
            {
                using (DBSaveImageService service = new DBSaveImageService())
                {
                    service.RemoveImageData(Guid.Parse("c07dc6e3-001d-4071-a3a7-40745b05087d"));
                    service.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}