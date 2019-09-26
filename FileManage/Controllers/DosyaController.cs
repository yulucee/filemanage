using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Net;
using System.Web.UI;
using FileManage.Filtreler;
using FileManageDAL.BusinessLayer.Abstract;
using FileManageDAL.BusinessLayer.Concrete;
using FileManageDAL.Models;
using FileManageDAL.BusinessLayer.Entities;

namespace FileManage.Controllers
{
    [ActionFiltre]
    public class DosyaController : Controller
    {
        private IDosyaDal dosyaDal;
        public DosyaController()
        {
            this.dosyaDal = new EfDosyaDal();
        }
        public DosyaController(IDosyaDal dosyaDal)
       {
            this.dosyaDal = dosyaDal;
       }
        [HttpPost]
        public ActionResult DosyaYukle(DosyaYukleme yuklenecekDosya)
        {
            var result = dosyaDal.DosyaYukle(yuklenecekDosya);
            if(result.Code == 0)
            {
                TempData["YuklemeHata1"] = result.Message;
                return RedirectToAction("AnaSayfa", "Klasor");
            }
            else
            {
                TempData["Basarili1"] = result.Message;
                return RedirectToAction("AnaSayfa", "Klasor");
            }
        }
        public ActionResult Edits(int DosyaId, string DosyaAdi)
        {
            bool result = false;
            var sonuc = dosyaDal.Edits(DosyaId, DosyaAdi);
            if (sonuc.Code == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Sil(int DosyaId)
        {
            var result = false;
            var sonuc = dosyaDal.Sil(DosyaId);
            result = (sonuc.Code == 1) ? result = true : result = false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult IcShare(string DosyaId, string KullaniciId, string Checked)
        {
            var sonuc = dosyaDal.IcShare(DosyaId, KullaniciId, Checked);
            if (sonuc.Code == 0)
            {
                TempData["dosyasharehatasi"] = sonuc.Message;
                return RedirectToAction("AnaSayfa","Klasor");
            }
            else
            {
                TempData["dosyaicpaylasimbasarili"] = sonuc.Message;
                 return RedirectToAction("AnaSayfa", "Klasor");
            }
            
        }
    }
}