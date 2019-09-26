using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography; // sifreleme 
using System.Net.Mail;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using FileManage.Filtreler;
using FileManage.TCKimlik;
using System.Web.Mvc.Html;
using FileManageDAL.BusinessLayer.Entities;
using FileManageDAL.Models;
using FileManageDAL.BusinessLayer.Abstract;
using FileManageDAL.BusinessLayer.Concrete;

namespace FileManage.Controllers
{
    public class HomeController : Controller
    {

        private IHomeDal homeDal;
        public HomeController()
        {
            this.homeDal = new EfHomeDal(/*new filemanagerDB()*/);
        }
        public HomeController(IHomeDal homeDal)
        { 
            this.homeDal = homeDal;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Kullanici kullanici)
        {
            //var response = Request["g-recaptcha-response"];
            //string secretKey = "6LeSf5sUAAAAAAVPDiZ-BKKTDKrbvjZPFKRpGDmp";
            //var client = new WebClient();
            //var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            //var obj = JObject.Parse(result);
            //var status = (bool)obj.SelectToken("success");
            //if (status == true)
            //{
                var sonuc = homeDal.Index(kullanici);
                if(sonuc.Code == 0)
                {
                    TempData["girisHatasi"] = sonuc.Message;
                    return View();
                }
                else
                {
                    return RedirectToAction("AnaSayfa", "Klasor");
                }
            //}
            //else
            //{
            //    TempData["hataligiris"] = "Hatalı Giriş";
            //    return View();
            //}
        }
        public ActionResult KayıtOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayıtOl(string name,string soyad, string mail, string sifre)
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LeSf5sUAAAAAAVPDiZ-BKKTDKrbvjZPFKRpGDmp";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            if (status == true)
            {
                var sonuc = homeDal.KayıtOl(name, soyad, mail, sifre);
                if(sonuc.Code == 0)
                {
                    TempData["maildolu"] = sonuc.Message;
                    return View();
                }
                else
                {
                    TempData["uyekayitbasarili"] = sonuc.Message;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["kayithata"] = "Beklenmeyen bir hata oluştu";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult ParolamıUnuttum()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult ParolamıUnuttum(string username)
        {
            var result = homeDal.ParolamıUnuttum(username);
            if(result.Code == 0)
            {
                TempData["sifirlamaMailHatasi"] = result.Message;
            }
            else
            {
                TempData["mailbasarili"] = result.Message;
            }
            return View();
        }
        public ActionResult ResetPassword(string code, string sifre1, string sifre2)
        {
            string mail = "";
            var tempcode = "";
            if (TempData["mail"] == null)
            {
               mail = "";
            }
            else
            {
               tempcode = TempData["code"].ToString();
               mail = TempData["mail"].ToString();
            }
            var result = homeDal.ResetPassword(mail,tempcode,code, sifre1, sifre2);
            TempData["mail"] = result.Data;
            TempData["code"] = result.Message;
            if (result.Code == 0)
            {
                
                TempData["linkgecerlilik"] = result.Message;
                return RedirectToAction("Index", "Home");
            }
            else if(result.Code == 1)
            {
                TempData["sifreDegisikligi"] = result.Message;
                return View();
            }
            else if(result.Code == 2)
            {
                TempData["sifredegisikligi"] = result.Message;
                return RedirectToAction("Index", "Home");
            }
            else if(result.Code == 3)
            {
                TempData["sifreayni"] = result.Message;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["kontrolsifre"] = result.Message;
                return View();
            }
        } 
        public ActionResult KullanıcıEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KullanıcıEkle(long tckimlik, string adi, string soyadi, string dogumyili, string mailadresi, string sifre1, string sifre2)
        {
            var result = homeDal.KullanıcıEkle(tckimlik, adi, soyadi, dogumyili, mailadresi, sifre1, sifre2);
            if(result.Code == 0)
            {
                ViewBag.MailDoluAnasayfa = result.Message;
            }
            else if(result.Code == 1)
            {
                ViewBag.UyeKaydi = result.Message;
            }
            else if(result.Code == 2)
            {
                TempData["kullanicisifrehatasi"] = result.Message;
            }
            else
            {
                TempData["tckimlikyanlis"] = result.Message;
            }
            return View();
        }
    }  
} 