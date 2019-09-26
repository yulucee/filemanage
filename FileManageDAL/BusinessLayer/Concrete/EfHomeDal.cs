﻿using FileManageDAL.BusinessLayer.Abstract;
using FileManageDAL.BusinessLayer.Entities;
using FileManageDAL.BusinessLayer.Models;
using FileManageDAL.Common;
using FileManageDAL.Models;
using FileManageDAL.TCKimlik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FileManageDAL.BusinessLayer.Concrete
{
    public class EfHomeDal : IHomeDal
    {
        private filemanagerDB db;
        public EfHomeDal()
        {
            this.db = new filemanagerDB();
        }
        public ServiceResult Index(Kullanici kullanici)
        {
            ServiceResult result = new ServiceResult();
            var sifre = kullanici.KullaniciSifresi;
            var mail = kullanici.KullaniciMaili;
            var guid = db.Kullanicis.Where(x => x.KullaniciMaili == mail).Select(x => x.Guid).Single();
            var guidne = guid.ToString();
            var sifrelenecek = sifre + guidne;
            var shasifre = ExtensionMethod.sha256(sifrelenecek);
            var login = db.Kullanicis.Where(u => u.KullaniciMaili == kullanici.KullaniciMaili).SingleOrDefault();
            if (login == null)
            {
                result.Data = false;
                result.Code = 0;
                result.Message = "Kullanıcı parola veya şifresi hatalı";
                return result;
            }
            else if (login.KullaniciMaili == mail && login.KullaniciSifresi == shasifre)
            {
                HttpContext.Current.Session["kullaniciId"] = login.KullaniciId;
                HttpContext.Current.Session["kullaniciMaili"] = login.KullaniciMaili;
                HttpContext.Current.Session["kullaniciAdi"] = login.KullaniciAdi;
                HttpContext.Current.Session["kullaniciYetki"] = login.YetkiId;
                result.Code = 1;
                result.Data = true;
                return result;
            }
            else
            {
                result.Data = false;
                result.Code = 0;
                result.Message = "Hatalı Giriş";
                return result;
            }
        }
        public ServiceResult KayıtOl(string name, string soyad, string mail, string sifre)
        {
            ServiceResult result = new ServiceResult();
            var ismailexist = db.Kullanicis.Any(x => x.KullaniciMaili == mail);
            if (ismailexist == true)
            {
                result.Data = false;
                result.Code = 0;
                result.Message = "Bu mail daha önce alınmış";
                return result;
            }
            else
            {
                var kullanicisifre = sifre;
                Guid g;
                g = Guid.NewGuid();
                var guidkullanici = g.ToString(); ;
                var sifrelenecekveri = kullanicisifre + guidkullanici;
                var shasifre = ExtensionMethod.sha256(sifrelenecekveri);
                KullaniciTbEkle(name, soyad, mail, shasifre, guidkullanici,2, null, null, null);
                result.Code = 1;
                result.Data = true;
                result.Message = "Uye kaydi tamamlanmıştır.";
                return result;
            }
        }
        public ServiceResult ParolamıUnuttum(string username)
        {
            ServiceResult result = new ServiceResult();
            var login = db.Kullanicis.Where(u => u.KullaniciMaili == username).SingleOrDefault();
            if (login == null)
            {
                result.Data = false;
                result.Code = 0;
                result.Message = "Mail Başarıyla gönderilmiştir";
                return result;
            }
            else
            {
                var ip = "::1";
                Guid g;
                g = Guid.NewGuid();
                var guid = g.ToString();
                var link = "http://localhost:51152/Home/ResetPassword?code=" + guid;
                var body = "Şifrenizi sıfırlamak için linke tıklayın" + "\n" + link;
                string subject = "Parolamı sıfırla";
                var gonderilecekmail = username;
                MailTbEkle(username, guid, ip, null);
                SendEmail(body, subject, gonderilecekmail);
                result.Data = true;
                result.Code = 1;
                result.Message = "Mail başarıyla gönderilmiştir";
                return result;
            }
        }
        public ServiceResult ResetPassword(string mail,string tempcode,string code, string sifre1, string sifre2)
        {
            
            ServiceResult service = new ServiceResult();
            if (code != null)
            {
                Mail mailler = db.Mails.SingleOrDefault(x => x.Guid == code);
                mail = mailler.MailAdresi;
                var result = mailler.Result;
                if (mail != null && result == null)
                {
                    service.ExternalData = false;
                    service.Code = 1;
                    service.Data = mail;
                    service.Message = code;
                    return service;
                }
                else
                {
                    service.Data = mail;
                    service.Code = 0; 
                    service.Message = code;
                    return service;
                }
            }
            else
            {
                var confirmsifre = sifre1;
                var confirmsifre2 = sifre2;
                if (confirmsifre == confirmsifre2)
                {
                    var sifre = db.Kullanicis.Where(x => x.KullaniciSifresi == confirmsifre).Select(x => x.KullaniciAdi).SingleOrDefault();
                    if (sifre == null)
                    {

                        Guid g;
                        g = Guid.NewGuid();
                        var guidkullanici = g;
                        var secretcode = tempcode;
                        var mailadresi = mail;
                        Kullanici kullanici = db.Kullanicis.SingleOrDefault(x => x.KullaniciMaili == mailadresi);
                        Mail mails = db.Mails.SingleOrDefault(x => x.Guid == secretcode);
                        kullanici.Guid = guidkullanici.ToString();
                        var sifrelenecekveri = confirmsifre + guidkullanici;
                        var shasifre = ExtensionMethod.sha256(sifrelenecekveri);
                        db.Entry(mails).State = System.Data.Entity.EntityState.Modified;
                        mails.Result = true;
                        db.Entry(kullanici).State = System.Data.Entity.EntityState.Modified;
                        var ismailexist = db.Kullanicis.Any(x => x.KullaniciMaili == mailadresi);
                        if (ismailexist == true)
                        {
                            service.Code = 2; 
                            service.Message = "Sifreniz Basariyla degistirilmistir"; 
                            kullanici.KullaniciSifresi = shasifre;
                            db.SaveChanges();
                            return service;
                        }
                        else
                        {
                            service.Code = 1;
                            service.Message = "Hata";
                            return service;
                        }
                    }
                    else
                    {
                        service.Code = 3;
                        service.Data = false;
                        service.Message = "Şifreniz önceki şifrenizden farklı olmalıdır";
                        return service;
                    }
                }
                else
                {
                    service.Data = false;
                    service.Code = 4;
                    service.Message = "Sifreler uyusmadi";
                    return service;
                }
            }
        }
        public ServiceResult KullanıcıEkle(long tckimlik, string adi, string soyadi, string dogumyili, string mailadresi, string sifre1, string sifre2)
        {
            KPSPublicSoapClient sorgula = new KPSPublicSoapClient();
            ServiceResult result = new ServiceResult();
            long tckimlikno = tckimlik;
            var dogumyilikaldir = dogumyili.Remove(0, 6);
            var dogumyil = Convert.ToInt32(dogumyilikaldir);
            string ad = adi.ToUpper(new System.Globalization.CultureInfo("tr-TR", false));
            string soyad = soyadi.ToUpper(new System.Globalization.CultureInfo("tr-TR", false));
            var sonuc = sorgula.TCKimlikNoDogrula(tckimlikno, ad, soyad, dogumyil);
            if (sonuc == true)
            {
                var ismailexist = db.Kullanicis.Any(x => x.KullaniciMaili == mailadresi);
                if (ismailexist == true)
                {
                    result.Code = 0;
                    result.Data = false;
                    result.Message = "Bu mail daha önce alınmış";
                    return result;
                }
                else
                {
                    if (sifre1 == sifre2)
                    {
                        var kullanicisifre = sifre1;
                        Guid g;
                        g = Guid.NewGuid();
                        var guidkullanici = g.ToString();
                        var sifrelenecekveri = kullanicisifre + guidkullanici;
                        var shasifre = ExtensionMethod.sha256(sifrelenecekveri);
                        var yetki = Convert.ToInt32(YetkiTipi.Uye.Value);
                        var ekleyen = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
                        KullaniciTbEkle(adi, soyadi, mailadresi, shasifre, guidkullanici, yetki, ekleyen, tckimlikno, dogumyil);
                        result.Code = 1;
                        result.Data = true;
                        result.Message = "Uye kaydi tamamlanmıştır.";
                        return result;
                    }
                    else
                    {
                        result.Code = 2;
                        result.Data = false;
                        result.Message = "Şifreler uyuşmadı";
                        return result;
                    }
                }
            }
            else
            {
                result.Code = 3;
                result.Data = false;
                result.Message = "Böyle bir kişi bulunamadı";
                return result;
            }
        }
        public void KullaniciTbEkle(string KullaniciAdi, string Soyadi, string KullaniciMaili, string KullaniciSifresi, string Guid, int? YetkiId, int? KimEkledi, long? tc, int? DogumYili)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciMaili = KullaniciMaili;
            kullanici.KullaniciAdi = KullaniciAdi;
            kullanici.KullaniciSoyadi = Soyadi;
            kullanici.KullaniciSifresi = KullaniciSifresi;
            kullanici.Guid = Guid;
            kullanici.YetkiId = YetkiId;
            kullanici.KimEkledi = KimEkledi;
            kullanici.TC = tc;
            kullanici.DogumYili = DogumYili;
            db.Kullanicis.Add(kullanici);
            db.SaveChanges();
        }
        public void SendEmail(string body, string subject, string gonderilecekmail)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("coffeedeneme123@gmail.com", "1234Asdf");
            smtp.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("coffeedeneme123@gmail.com");
            mailMessage.Body = body;
            mailMessage.Subject = subject;
            mailMessage.To.Add(gonderilecekmail);
            smtp.Send(mailMessage);
        }
        public void MailTbEkle(string MailAdresi, string Guid, string ip, bool? result)
        {
            Mail mail = new Mail();
            mail.MailAdresi = MailAdresi;
            mail.Tarih = DateTime.Now;
            mail.Guid = Guid;
            mail.Result = result;
            mail.ip = ip;
            db.Mails.Add(mail);
            db.SaveChanges();
        }
    }
}
