using FileManageDAL.BusinessLayer.Abstract;
using FileManageDAL.BusinessLayer.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FileManage.Unittest
{
    [TestClass]
    public class UnitTest_EfKlasor_Test
    {

        private IKlasorDal klasorDal;
        public UnitTest_EfKlasor_Test()
        {
            this.klasorDal = new EfKlasorDal();
        }
        public UnitTest_EfKlasor_Test(IKlasorDal klasorDal)
        {
            this.klasorDal = klasorDal;
        }
        [TestMethod]
        public void Index_Check()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 1453;
                var result = klasorDal.AnaSayfa(id);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void Index_Check_IdNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.AnaSayfa(null);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void Index_Check_IdNotNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.AnaSayfa(null);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void Sil_Check_KlasorId()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 1459;
                var result = klasorDal.Sil(id);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void Sil_Check_KlasorIdWrong()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 100;
                var result = klasorDal.Sil(id);
                Assert.AreEqual(3, result.Code);
            }
        }
        [TestMethod]
        public void Sil_Check_OK()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 1459;
                var result = klasorDal.Sil(id);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void Edits_Check_DosyaIdNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "newdosya";
                var result = klasorDal.Edits(0,a);
                Assert.AreEqual(3, result.Code);
            }
        }
        [TestMethod]
        public void Edits_Check_KlasorAdiNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 1459;
                var result = klasorDal.Edits(id,null);
                Assert.AreEqual(4, result.Code);
            }
        }
        [TestMethod]
        public void Edits_IsPathExist()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 1459;
                var ad = "555";
                var result = klasorDal.Edits(id, ad);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void Edits_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 1459;
                var ad = "yeniklasoradi";
                var result = klasorDal.Edits(id, ad);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void Create_KlasorAdi_Null()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.Creates(null);
                Assert.AreEqual(3, result.Code);
            }
        }
        [TestMethod]
        public void Create_KlasorAdi_ContainsBad()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*a";
                var result = klasorDal.Creates(a);
                Assert.AreEqual(0,result.Code);
            }
        }
        [TestMethod]
        public void Create_KlasorAdi_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "787";
                var result = klasorDal.Creates(a);
                Assert.AreEqual(2, result.Code);
            }
        }
        [TestMethod]
        public void Create_KlasorAdi_IsExist()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "55";
                var result = klasorDal.Creates(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void KlasorAc_Check()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 1459;
                var result = klasorDal.KlasorAc(id);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void KlasorAc_Check_IdNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.KlasorAc(null);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void KlasorAc_Check_IdFalse()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var id = 100;
                var result = klasorDal.KlasorAc(id);
                Assert.AreEqual(2,result.Code);
            }
        }
        [TestMethod]
        public void CreateInFolder_OK()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "yeniIsim";
                var b = 1459;
                var result = klasorDal.CreateInFolder(a, b);
                Assert.AreEqual(2, result.Code);
            }
        }
        [TestMethod]
        public void CreateInFolder_KlasorAdiNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var b = 1459;
                var result = klasorDal.CreateInFolder(null, b);
                Assert.AreEqual(3, result.Code);
            }
        }
        [TestMethod]
        public void CreateInFolder_KlasorAdiFalseMethod()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*aa";
                var b = 1459;
                var result = klasorDal.CreateInFolder(a, b);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void CreateINFolder_KlasorAdiExist()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "66";
                var b = 1459;
                var result = klasorDal.CreateInFolder(a, b);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void RenameInFolder_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "degistir";
                var b = 1459;
                var c = 1460;
                var result = klasorDal.RenameINFolder(a, b, c);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void RenameInFolder_KlasorAdiNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var b = 1459;
                var c = 1460;
                var result = klasorDal.RenameINFolder(null, b, c);
                Assert.AreEqual(3, result.Code);
            }
        }
        [TestMethod]
        public void RenameInFolder_KlasorIdWrong()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "degistir";
                var b = 1459;
                var c = 1400;
                var result = klasorDal.RenameINFolder(a, b, c);
                Assert.AreEqual(2, result.Code);
            }
        }
        [TestMethod]
        public void RenameInFolder_KlasorAdiExist()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "66";
                var b = 1459;
                var c = 1460;
                var result = klasorDal.RenameINFolder(a, b, c);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void DeleteInFolder_Null()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 100;
                var b = 200;
                var result = klasorDal.DeleteINFolder(a, b);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void DeleteInFolder_OK()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1460;
                var b = 1459;
                var result = klasorDal.DeleteINFolder(a, b);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void DosyaInDelete_Null()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 100;
                var result = klasorDal.DosyaINDelete(a);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void DosyaInDelete_OK()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1453;
                var result = klasorDal.DosyaINDelete(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void DosyaInRename_OK()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1452;
                var b = "degistir";
                var c = 1449;
                var result = klasorDal.DosyaINRename(a, b, c);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void DosyaInRename_DosyaAdiNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1452;
                var c = 1449;
                var result = klasorDal.DosyaINRename(a, null, c);
                Assert.AreEqual(4, result.Code);
            }
        }
        [TestMethod]
        public void DosyaInRename_DosyaIdWrong()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1000;
                var b = "degistir";
                var c = 1449;
                var result = klasorDal.DosyaINRename(a, b, c);
                Assert.AreEqual(3, result.Code);
            }
        }
        [TestMethod]
        public void DosyaInRename_DosyaExist()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1452;
                var b = "bozmadanonce.txt";
                var c = 1449;
                var result = klasorDal.DosyaINRename(a, b, c);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void CokluDownload_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*1452";
                var result = klasorDal.CokluDownload(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void CokluDownload_IdNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.CokluDownload(null);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void KlasorDosyaDownload_IdNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.KlasorDosyaDownload(null);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void KlasorDosyaDownload_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*1459";
                var result = klasorDal.KlasorDosyaDownload(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void KlasorDosyaDownload_Coklu_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*1459*1457";
                var result = klasorDal.KlasorDosyaDownload(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void PaylasilanlariTopluIndirme_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*1459";
                var result = klasorDal.PaylasilanlariTopluIndirme(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void PaylasilanlariTopluIndirme_IDNULL()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.PaylasilanlariTopluIndirme(null);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void KlasorIciDosyaDownload_IDNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.KlasorIciDosyaDownload(null);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void KlasorIciDosyaDownload_OK()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*1456";
                var result = klasorDal.KlasorIciDosyaDownload(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void KlasIcIDosyaDownload_dosyaNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*1452";
                var result = klasorDal.KlasorIciDosyaDownload(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void KlasIcIDosyaDownload_klasorNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*1460";
                var result = klasorDal.KlasorIciDosyaDownload(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void KlasorDownload_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1459;
                var result = klasorDal.KlasorDownload(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void KlasorDownload_KlasorIDnull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 100;
                var result = klasorDal.KlasorDownload(a);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void KlasorDownload_DosyaIDnull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 100;
                var result = klasorDal.DosyaDownload(a);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void DosyaDownload_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1457;
                var result = klasorDal.DosyaDownload(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void DosyaDownload_IsNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 100;
                var result = klasorDal.DosyaDownload(a);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void FileCut_IsNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "none";
                var result = klasorDal.FileCut(a);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void FileCut_OK()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*1457";
                var result = klasorDal.FileCut(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void FilePaste_DosyaId_Null()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.FilePaste(0,null);
                Assert.AreEqual(0, result.Code);
            }
        }
        [TestMethod]
        public void FilePaste_DosyaId_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.FilePaste(1457, null);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void FilePaste_Scenario3()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.FilePaste(1459,"*1456");
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void FilePaste_Scenario4()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.FilePaste(1459, "*100");
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void FilePaste_Scenario5()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.FilePaste(0, null);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void Info_IdNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 0;
                var result = klasorDal.Info(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void Info_OK_Scenario2()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1788;
                var result = klasorDal.Info(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void LinkKapat_OK()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 261;
                var b = 1;
                var result = klasorDal.LinkKapat2(a, b);
                Assert.IsTrue(result.Data);
            }
        }
        [TestMethod]
        public void LinkKapat_Scnario2()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1787;
                var b = 1;
                var result = klasorDal.LinkKapat2(a, b);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void LinkKapat_Scnario3()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 261;
                var b = 2;
                var result = klasorDal.LinkKapat2(a, b);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void LinkKapat_Scnario4()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 261;
                var b = 3;
                var result = klasorDal.LinkKapat2(a, b);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void VideoPlayer_Ok_txt()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1457;
                var result = klasorDal.VideoPlayer(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void VideoPlayer_Ok_png()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1453;
                var result = klasorDal.VideoPlayer(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void VideoPlayer_Ok_mp4()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1493;
                var result = klasorDal.VideoPlayer(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void VideoPlayer_Ok_jpeg()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1495;
                var result = klasorDal.VideoPlayer(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void VideoPlayer_Ok_pdf()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 1494;
                var result = klasorDal.VideoPlayer(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void VideoPlayer_null()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = 100;
                var result = klasorDal.VideoPlayer(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void LinkPaylas_null()
        {
            using (TransactionScope ts  = new TransactionScope())
            {
                var result = klasorDal.LinkPaylas(null);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void LinkPaylas_Ok()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "261";
                var result = klasorDal.LinkPaylas(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void LinkPaylas_Coklu()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a ="*1494*1495";
                var result = klasorDal.LinkPaylas(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void LinkPaylas_Coklu_2()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "*1494*1495*1493";
                var result = klasorDal.LinkPaylas(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void LinkPaylas_Coklu_3()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.LinkPaylas(null);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void PaylastigimLinkler()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.PaylastigimLinkler();
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void PaylastigimLinkler_Scenario2()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.PaylastigimLinkler();
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void ShareWithLink()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "e7b98c71-07a4-4775-959e-6af4a6d2d8f2";
                var result = klasorDal.ShareWithLink(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void ShareWithLink_CodeWrong()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "sdasfasasd";
                var result = klasorDal.ShareWithLink(a);
                Assert.AreEqual(1, result.Code);
            }
        }
        [TestMethod]
        public void ShareWithLink_CodeNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var result = klasorDal.ShareWithLink(null);
                Assert.AreEqual(3, result.Code);
            }
        }
        [TestMethod]
        public void ShareWithLink_ErisNull()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var a = "sad959e-6af4a6d2d8f2";
                var result = klasorDal.ShareWithLink(a);
                Assert.IsNotNull(result);
            }
        }
        [TestMethod]
        public void Shareas()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var b = "seee";
                var ressssult = klasorDal.ShareWithLink(b);
                Assert.IsNotNull(ressssult);
            }
        }
    }
}
