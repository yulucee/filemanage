using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileManageDAL.BusinessLayer.Abstract;
using FileManageDAL.BusinessLayer.Concrete;
using FileManageDAL.BusinessLayer.Entities;
using FileManageDAL.Models;

namespace FileManage.Controllers
{
    public class PaylasilanlarController : Controller
    {
        private IPaylasilanlarDal paylasilanlarDal;
        public PaylasilanlarController()
        {
            this.paylasilanlarDal = new EfPaylasilanlarDal();
        }
        public PaylasilanlarController(IPaylasilanlarDal paylasilanlarDal)
        {
            this.paylasilanlarDal = paylasilanlarDal;
        }
        public ActionResult Index(int? id)
        {
            var result = paylasilanlarDal.Index(id);
            if(result.Code == 1)
            {
                return View(result.Data);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult PaylasilanlariAc(int? id)
        {
            ViewBag.MainId = id;
            var result = paylasilanlarDal.PaylasilanlariAc(id);
            if(result.Code == 1)
            {
                return View(result.Data);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Paylastiklarim(int? id)
        {
            var result = paylasilanlarDal.Paylastiklarim(id);
            if(result.Code == 1)
            {
                return View(result.Data);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult PaylastiklarimiAc(int? id)
        {
            var result = paylasilanlarDal.PaylastiklarimiAc(id);
            if(result.Code == 1)
            {
                return View(result.Data);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Bilgi(string id)
        {
            var result = paylasilanlarDal.Bilgi(id);
            if(result.Code == 0)
            {
                TempData["dosyasharehatasi"] = result.Data;
                return RedirectToAction("AnaSayfa", "Klasor");
            }
            else
            {
                ViewBag.kullanicilistesi = result.Data;
                return View();
            }
        }
        public ActionResult BenimlePaylasanlarBilgi(string id)
        {
            var result = paylasilanlarDal.BenimlePaylasilanlarBilgi(id);
            if(result.Code == 0)
            {
                TempData["dosyasharehatasi"] = result.Data;
                return RedirectToAction("AnaSayfa", "Klasor");
            }
            else
            {
                ViewBag.kullaniciliste = result.Data;
                return View();
            }
        }        
        public ActionResult PaylasilanaEkle(DosyaYukleme yuklenecekDosya, int klasorId)
        {
            var result = paylasilanlarDal.PaylasilanaEkle(yuklenecekDosya, klasorId);
            if(result.Code == 0)
            {
                TempData["YuklemeHata"] = result.Data;
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if(result.Code ==1)
            {
                ViewBag.Message = result.Data;
                return View();
            }
            else if(result.Code == 2)
            {
                TempData["Basarili"] = result.Data;
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                TempData["YuklemeHata"] = result.Data;
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        public ActionResult YetkiKaldirma(int PaylasmaId) // Paylasilan dosyalardan silme işlemi...
        {
            var sonuc = paylasilanlarDal.YetkiKaldirma(PaylasmaId);
            bool result = false;
            var html = "";
            if (sonuc.Code == 1)
            {
                result = true;
                html = sonuc.Data;
                return Json(new { result = result, html = html }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            } 
        }
    }
}