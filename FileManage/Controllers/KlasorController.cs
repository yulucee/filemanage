using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ionic.Zip;
using Ionic.Zlib;
using FileManage.Filtreler;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.ModelBinding;
using System.Net.Mail;
using FileManageDAL.BusinessLayer.Entities;
using FileManageDAL.BusinessLayer.Models;
using FileManageDAL.Models;
using FileManageDAL.BusinessLayer.Abstract;
using FileManageDAL.BusinessLayer.Concrete;

namespace FileManage.Controllers
{
    
    public class KlasorController : Controller
    {
        private IKlasorDal klasorDal;
        public KlasorController()
        {
            this.klasorDal = new EfKlasorDal();
        }
        public KlasorController(IKlasorDal klasorDal)
        {
            this.klasorDal = klasorDal;
        }
        public ActionResult AnaSayfa(int? id)
        {
            ViewBag.YuklemeHata1 = TempData["YuklemeHata1"];
            ViewBag.Basarili1 = TempData["Basarili1"];
            ViewBag.IcindeOldugumKlasorId = id;
            var result = klasorDal.AnaSayfa(id);
            if(result.Code == 1)
            {
                return View(result.Data);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [ActionFiltre]
        public ActionResult Sil(int KlasorId)
        {
            bool result = false;
            var sonuc = klasorDal.Sil(KlasorId);
            if(sonuc.Code == 1)
            {
                TempData["Basarili1"] = sonuc.Message;
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [ActionFiltre]
        public ActionResult Edits(int DosyaId, string KlasorAdi)
        {
            bool result = false;
            var sonuc = klasorDal.Edits(DosyaId, KlasorAdi);
            if(sonuc.Code == 0)
            {
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [ActionFiltre]
        public ActionResult Creates(string YeniKlasorAdi)
        {
            bool result = false;
            var sonuc = klasorDal.Creates(YeniKlasorAdi);
            if(sonuc.Code == 0)
            {
                result = sonuc.Data;
                return Json(JsonRequestBehavior.AllowGet);
            }
            else if (sonuc.Code == 1)
            {
                result = sonuc.Data;
                return Json(result,JsonRequestBehavior.AllowGet);
            }
            else
            {
                result = sonuc.Data;
                TempData["Basarili1"] = sonuc.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        /************************************************************************************************/
        /************************************************************************************************/
        /**************************KLASOR ICINDEKİ ISLEMLER ICIN*****************************************/
        /************************************************************************************************/
        /************************************************************************************************/
        [ActionFiltre]
        public ActionResult KlasorAc(int? id)
        {
            //var dosyaYolu = (db.Klasors.Find(id).KlasorYolu.Split("Dosyalarım")[1]);
            ViewBag.YuklemeHata = TempData["YuklemeHata"];
            ViewBag.Basarili = TempData["Basarili"];
            ViewBag.MainId = id;
            TempData["klasordownloadicinid"] = id;
            var result = klasorDal.KlasorAc(id);
            ViewBag.MapList = result.ExternalData;
            return View(result.Data);
        }
        [ActionFiltre]
        public ActionResult CreateINFolder(string YeniKlasorAdi, int EskiKlasorId)
        {
            bool result = false;
            var sonuc = klasorDal.CreateInFolder(YeniKlasorAdi, EskiKlasorId);
            if(sonuc.Code == 0)
            {
                TempData["YuklemeHata"] = sonuc.Message;
                result = sonuc.Data;
                return Json(JsonRequestBehavior.AllowGet);
            }
            else if(sonuc.Code == 1)
            {
                TempData["YuklemeHata"] = sonuc.Message;
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["Basarili"] = sonuc.Message;
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [ActionFiltre]
        public ActionResult RenameINFolder(string KlasorAdi, int EskiKlasorId, int KlasorId)
        {
            bool result = false;
            var sonuc = klasorDal.RenameINFolder(KlasorAdi, EskiKlasorId, KlasorId);
            if(sonuc.Code == 0)
            {
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [ActionFiltre]
        public ActionResult DeleteINFolder(int KlasorId, int EskiKlasorId)
        {
            bool result = false;
            var sonuc = klasorDal.DeleteINFolder(KlasorId, EskiKlasorId);
            if(sonuc.Code == 1)
            {
                TempData["Basarili"] = sonuc.Message;
                result = sonuc.Data;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [ActionFiltre]
        public ActionResult DosyaINYukle()
        {
            return View();
        }
        [HttpPost]
        [ActionFiltre]
        public ActionResult DosyaINYukle(DosyaYukleme yuklenecekDosya, int klasorId)
        {
            var sonuc = klasorDal.DosyaINYukle(yuklenecekDosya, klasorId);
            if(sonuc.Code == 0)
            {
                TempData["YuklemeHata"] = sonuc.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if(sonuc.Code == 1)
            {
                ViewBag.Message = sonuc.Message;
                return View();
            }
            else if (sonuc.Code == 2)
            {
                TempData["Basarili"] = sonuc.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                TempData["YuklemeHata"] = sonuc.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        [ActionFiltre]
        public ActionResult DosyaINDelete(int DosyaId)
        {
            bool result = false;
            var sonuc = klasorDal.DosyaINDelete(DosyaId);
            if(sonuc.Code == 1)
            {
                result = sonuc.Data;
                TempData["Basarili"] = sonuc.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [ActionFiltre]
        public ActionResult DosyaINRename(int DosyaId, string DosyaAdi, int EskiKlasorId)
        {
            bool result = false;
            var sonuc = klasorDal.DosyaINRename(DosyaId, DosyaAdi, EskiKlasorId);
            if(sonuc.Code == 0)
            {
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else if (sonuc.Code == 1)
            {
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        /************************************************************************************/
        /************************************************************************************/
        /*****************************INDIRME ISLEMLERİ**************************************/
        /************************************************************************************/
        /************************************************************************************/
        //Coklu Dosya Download
        [HttpGet]
        [ActionFiltre]
        //İnaktif, kullanımda değil..
        public FileResult CokluDownload(string DosyaId)
        {
            var result = klasorDal.CokluDownload(DosyaId);
            if(result.Code == 1)
            {
                return File(result.Data, "application/zip", "Indirilenler.zip");
            }
            else
            {
                return null;
            }
        } 
        //anasayfada klasor Download
        [HttpGet]
        public FileResult KlasorDosyaDownload(string IDs) // seçilenleri indir butonu
        {
            var result = klasorDal.KlasorDosyaDownload(IDs);
            if(result.Code == 1)
            {
                return File(result.Data, "application/zip", "Indirilenler.zip");
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        [ActionFiltre]
        public FileResult PaylasilanlariTopluIndirme(string IDs)
        {
            var sonuc = klasorDal.PaylasilanlariTopluIndirme(IDs);
            if(sonuc.Code == 1)
            {
                return File(sonuc.Data, "application/zip", "Indirilenler.zip");
            }
            else
            {
                return null;
            }
        }
        //Klasoricinde Download
        [HttpGet]
        [ActionFiltre]
        public FileResult KlasorIciDosyaDownload(string IDs)
        {
            var sonuc = klasorDal.KlasorIciDosyaDownload(IDs);
            if(sonuc.Code == 1)
            {
                return File(sonuc.Data, "application/zip", "Indirilenler.zip");
            }
            else
            {
                return null;
            }
        }
        //tek klasor download
        [ActionFiltre]
        public ActionResult KlasorDownload(int KlasorId)
        {
            var sonuc = klasorDal.KlasorDownload(KlasorId);
            if(sonuc.Code == 1)
            {
                return File(sonuc.Data, "application/zip", "Indirilenler.zip");
            }
            else
            {
                return null;
            }
        }
        [ActionFiltre]
        public FileResult DosyaDownload(int DosyaId)
        {
            var sonuc = klasorDal.DosyaDownload(DosyaId);
            if(sonuc.Code == 1)
            {
                return File(sonuc.Data, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(sonuc.Message));
            }
            else
            {
                return null;
            }
        }
        /*************************************************************************************/
        /*************************************************************************************/
        /*************************************************************************************/
        /*************************************************************************************/
        public ActionResult VideoPlayer(int DosyaId)
        {
            bool result = false;
            var sonuc = klasorDal.VideoPlayer(DosyaId);
            if(sonuc.Code == 0)
            {
                result = true;
                return Json(data: new { result = result, dosyatipi = sonuc.Data, url = sonuc.Message }, behavior: JsonRequestBehavior.AllowGet);
            }
            else if(sonuc.Code == 1)
            {
                result = true;
                return Json(new { result = result, dosyatipi = sonuc.Data, url = sonuc.Message }, JsonRequestBehavior.AllowGet);
            }
            else if (sonuc.Code ==2)
            {
                result = true;
                var aa = sonuc.Message;
                string[] bol = aa.Split(',');
                var url = bol[0];
                var dosyaadi = bol[1];
                return Json(new { result = result, dosyatipi = sonuc.Message, url = url, dosyaadi = dosyaadi }, JsonRequestBehavior.AllowGet);
            }
            else if(sonuc.Code == 3)
            {
                result = true;
                return Json(new { result = result, dosyatipi = sonuc.Data, url = sonuc.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [ActionFiltre]
        public ActionResult FileCut(string Dosyaid)
        {
            var result = klasorDal.FileCut(Dosyaid);
            if(result.Code == 0)
            {
                TempData["secimyap"] = result.Message;
            }
            if(result.Code == 1)
            {
                TempData["tasinacakdosya"] = Dosyaid;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        [ActionFiltre]
        public ActionResult FilePaste(int DosyaId)
        {
            var tempdosyaid = TempData["tasinacakdosya"].ToString();
            var result = klasorDal.FilePaste(DosyaId, tempdosyaid);
            if(result.Code == 0)
            {
                TempData["yapistirmaHatasi"] = result.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if(result.Code == 1)
            {
                TempData["isexistcutfile"] = result.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if (result.Code == 2)
            {
                TempData["isexistcutfile"] = result.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if(result.Code == 3)
            {
                TempData["isexistcutfile"] = result.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if(result.Code == 4)
            {
                TempData["isexistcutfile"] = result.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
            foreach (var key in TempData.Keys.ToList())
            {
                TempData.Remove(key);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        [ActionFiltre]
        public ActionResult Info(int id) //Paylas dediginde çıkan ekran
        {
            var sonuc = klasorDal.Info(id);
            if(sonuc.Code == 1)
            {
                return Json(data: sonuc.Data, behavior: JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult YetkiDegisikligiAjax(Dictionary<String, Gift> myDictionary, int KlasorDosyaId)
        {
            bool result = false;
            var sonuc = klasorDal.YetkiDegisikligiAjax(myDictionary, KlasorDosyaId);
            if(sonuc.Code == 0)
            {
                TempData["yetkidegisikligihata"] = sonuc.Message;
                return RedirectToAction("AnaSayfa", "Klasor");
            }
            else if(sonuc.Code == 1)
            {
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else if (sonuc.Code == 3)
            {
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result = sonuc.Data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [ActionFiltre]
        public ActionResult LinkPaylas(string DosyaId)
        {
            var sonuc = klasorDal.LinkPaylas(DosyaId);
            if(sonuc.Code == 0)
            {
                return Json(new { result = sonuc.Data }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = sonuc.Data, link = sonuc.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ShareWithLink(string code)
        {
            var sonuc = klasorDal.ShareWithLink(code);
            if(sonuc.Code == 1)
            {
                return View(sonuc.Data);
            }
            else
            {
                TempData["sharewithlinkhatasie0"] = sonuc.Message;
                return RedirectToAction("AnaSayfa", "Klasor");
            }
        }
        [ActionFiltre]
        public ActionResult PaylastigimLinkler()
        {
            var result = klasorDal.PaylastigimLinkler();
            if(result.Code == 1)
            {
                return View(result.Data);
            }
            else
            {
                return null;
            }
        }
        [ActionFiltre]
        public ActionResult LinkKapat2(int DosyaId, int Checked)
        {
            var result = klasorDal.LinkKapat2(DosyaId, Checked);
            if(result.Code == 1)
            {
                return Json(new { result = result.Data }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = result.Data }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}