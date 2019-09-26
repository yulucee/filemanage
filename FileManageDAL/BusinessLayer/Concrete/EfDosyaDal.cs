using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using FileManageDAL.BusinessLayer.Abstract;
using FileManageDAL.BusinessLayer.Entities;
using FileManageDAL.BusinessLayer.Models;
using FileManageDAL.Common;
using FileManageDAL.Models;

namespace FileManageDAL.BusinessLayer.Concrete
{
    
    public class EfDosyaDal : IDosyaDal
    {
        private filemanagerDB db;
        public EfDosyaDal()
        {
            this.db = new filemanagerDB();
        }
        public ServiceResult Edits(int DosyaId, string DosyaAdi)
        {
            ServiceResult result = new ServiceResult();
            Dosya dosya = db.Dosyas.SingleOrDefault(x => x.DosyaId == DosyaId);
            if(dosya == null)
            {
                result.Data = false;
                return result;
            }
            db.Entry(dosya).State = System.Data.Entity.EntityState.Modified;
            dosya.KullaniciId = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
            var eskiyol = dosya.DosyaYolu;
            var dosyaAdiwithExtension = DosyaAdi + dosya.DosyaTipi;
            var dosyanewpath = HostingEnvironment.MapPath("~/Dosyalarım/" + HttpContext.Current.Session["kullaniciId"] + "/" + dosyaAdiwithExtension);
            var ispathExist = db.Dosyas.Any(x => x.DosyaYolu == dosyanewpath && x.Durumu != true);
            if (ispathExist == true)
            {
                result.Code = 0;
                result.Data = false;
                result.Message = "Dosya Zaten Var";
                return result;
            }
            else
            {
                dosya.DosyaAdi = dosyaAdiwithExtension;
                dosya.DosyaYolu = dosyanewpath;
                System.IO.File.Move(eskiyol, dosyanewpath);
                db.SaveChanges();
                result.Code = 1;
                result.Message = "Başarılı";
                return result;
            }
        }
        public ServiceResult Sil(int DosyaId)
        {
            ServiceResult result = new ServiceResult();
            Dosya dosya = db.Dosyas.SingleOrDefault(x => x.DosyaId == DosyaId);
            if (dosya != null)
            {
                DBSil(DosyaId, dosya);
                result.Code = 1;
                result.Data = true;
            }
            else
            {
                result.Data = false;
            }
            return result;
        }
        public ServiceResult IcShare(string DosyaId, string KullaniciId, string Checked)
        {
            ServiceResult result = new ServiceResult();
            if (String.IsNullOrWhiteSpace(DosyaId))
            {
                result.Code = 0;
                result.Message = "Bir dosya secimi yapılmadı!!! Lutfen paylasmak istediginiz dosyayi seciniz..";
                return result;
            }
            if (String.IsNullOrWhiteSpace(KullaniciId))
            {
                result.Code = 0;
                result.Message = "Kullanıcı secimi yapılmadı!!! Lutfen bir kullanici seciniz..";
                return result;
            }
            if (String.IsNullOrWhiteSpace(Checked))
            {
                result.Code = 0;
                result.Message = "Yetki Secimi Yapılmadı!!! Lutfen bir yetki secimi yapiniz..";
                return result;
            }
            string[] parcalar = ExtensionMethod.Parcala(DosyaId);
            List<int> dosyaIds = Array.ConvertAll(parcalar, int.Parse).ToList();
            List<Dosya> dosya = db.Dosyas.Where(x => dosyaIds.Any(v => v == x.DosyaId && x.DosyaMi == true && x.Durumu == null)).ToList();
            List<Dosya> klasor = db.Dosyas.Where(x => dosyaIds.Any(v => v == x.DosyaId) && x.DosyaMi == null && x.Durumu == null).ToList(); // klasorleri bul
            int[] KullaniciIdArray = KullaniciId.Split(',').Select(int.Parse).ToArray();
            var list = new List<int>(KullaniciIdArray);
            int[] yetkiIdArray = Checked.Split(',').Select(int.Parse).ToArray();
            var yetkiliste = new List<int>(yetkiIdArray);
            var yetki = (yetkiliste.Count == 1) ? Convert.ToInt32(Checked) : 3;
            for (int i = 0; i < dosya.Count; i++)
            {
                var dosyaid = dosya[i].DosyaId;
                var dosyayolu = dosya[i].DosyaYolu;
                var dosyaismi = dosya[i].DosyaAdi;
                var dosyaparent = dosya[i].ParentId;
                List<Kullanici> kullanici = db.Kullanicis.Where(x => list.Any(v => v == x.KullaniciId)).ToList();
                Paylasilanlar paylas = new Paylasilanlar();
                for (int m = 0; m < kullanici.Count; m++)
                {
                    var kullaniciid = kullanici[m].KullaniciId;
                    var path = Path.Combine(HostingEnvironment.MapPath("~/Dosyalarım/" + kullaniciid + "/Paylasilanlar/" + HttpContext.Current.Session["kullaniciId"] + "/"), dosyaismi);
                    var targetpath = Path.Combine(HostingEnvironment.MapPath("~/Dosyalarım/" + kullaniciid + "/Paylasilanlar/" + HttpContext.Current.Session["kullaniciId"]));
                    var ispathexist = db.Paylasilanlars.Any(x => x.PaylasilaninYolu == path);
                    if (ispathexist != true)
                    {
                        var sonuc = (dosya[0].ParentId != null) ? null : dosyaparent;
                        var sessionkisi = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
                        PaylasilanlarTB_Ekle(dosyaid, dosyaismi, kullaniciid, sessionkisi, yetki, path, sonuc, true);
                        result.Code = 1;
                        result.Message = "Başarılı";
                        if (!System.IO.Directory.Exists(targetpath))
                        {
                            System.IO.Directory.CreateDirectory(targetpath);
                        }
                        System.IO.File.Copy(dosyayolu, path, true);
                    }
                }
            }
            for (int i = 0; i < klasor.Count; i++)
            {
                var klasorid = klasor[i].DosyaId;
                var klasorismi = klasor[i].DosyaAdi;
                var klasoryolu = klasor[i].DosyaYolu;
                var klasorparentcheck = klasor[i].ParentId;
                List<Kullanici> kullanici = db.Kullanicis.Where(x => list.Any(v => v == x.KullaniciId)).ToList();
                for (int m = 0; m < kullanici.Count; m++)
                {
                    var kullaniciid = kullanici[m].KullaniciId;
                    var path = Path.Combine(HostingEnvironment.MapPath("~/Dosyalarım/" + kullaniciid + "/Paylasilanlar/" + HttpContext.Current.Session["kullaniciId"] + "/"), klasorismi);
                    var targetpath = Path.Combine(HostingEnvironment.MapPath("~/Dosyalarım/" + kullaniciid + "/Paylasilanlar/" + HttpContext.Current.Session["kullaniciId"]));
                    var altklasorler = db.Dosyas.Where(x => x.DosyaYolu.Contains(klasoryolu) && x.DosyaMi == null && x.Durumu == null).Select(x => x).ToList();
                    var altdosyalar = db.Dosyas.Where(x => x.DosyaYolu.Contains(klasoryolu) && x.DosyaMi == true && x.Durumu == null).Select(x => x).ToList();
                    for (int x = 0; x < altklasorler.Count; x++)
                    {
                        var parentid = altklasorler[x].ParentId;
                        var klasorunparentpathi = db.Dosyas.Where(d => d.DosyaId == parentid).Select(d => d.DosyaYolu).SingleOrDefault();
                        var parentpath = klasorunparentpathi.ToString();
                        var remove = parentpath.Remove(0, 64);
                        var paylasmayolu = targetpath + @"\" + remove + @"\" + altklasorler[x].DosyaAdi;
                        var ispathexist = db.Paylasilanlars.Any(k => k.PaylasilaninYolu == paylasmayolu);
                        if (ispathexist != true)
                        {
                            var sonuc = (x == 0) ? null : parentid;
                            var sessionkisi = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
                            PaylasilanlarTB_Ekle(altklasorler[x].DosyaId, altklasorler[x].DosyaAdi, kullaniciid, sessionkisi, yetki, paylasmayolu, sonuc, null);
                            result.Code = 1;
                            result.Message = "Başarılı";
                        }
                    }
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    for (int x = 0; x < altdosyalar.Count; x++)
                    {
                        var dosyayolu = altdosyalar[x].DosyaYolu;
                        var altdosyaparent = altdosyalar[x].ParentId;
                        var dosyanınparentpathi = db.Dosyas.Where(s => s.DosyaId == altdosyaparent && s.DosyaMi == null && s.Durumu == null).Select(s => s.DosyaYolu).SingleOrDefault();
                        var remove = dosyanınparentpathi.Remove(0, 64);
                        var pathchecking = targetpath + @"\" + remove + @"\" + altdosyalar[x].DosyaAdi;
                        var ispathexist = db.Paylasilanlars.Any(k => k.PaylasilaninYolu == pathchecking);
                        if (ispathexist != true)
                        {   
                            var sessionkullaniciId = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
                            PaylasilanlarTB_Ekle(altdosyalar[x].DosyaId, altdosyalar[x].DosyaAdi, kullaniciid, sessionkullaniciId, yetki, pathchecking, altdosyalar[x].ParentId, true);
                            result.Code = 1;
                            result.Message = "Başarılı";
                        }
                    }
                    foreach (string dirPath in Directory.GetDirectories(klasoryolu, "*", SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(klasoryolu, path));
                    foreach (string newPath in Directory.GetFiles(klasoryolu, "*.*",
                        SearchOption.AllDirectories))
                        System.IO.File.Copy(newPath, newPath.Replace(klasoryolu, path), true);
                }
            }
            return result;
        }
        public ServiceResult DosyaYukle(DosyaYukleme yuklenecekDosya)
        {
            ServiceResult result = new ServiceResult();
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in yuklenecekDosya.Files)
                    {
                        var filename = Path.GetFileName(item.FileName);
                        var path = Path.Combine(HostingEnvironment.MapPath("~/Dosyalarım/" + HttpContext.Current.Session["kullaniciId"] + "/"), filename);
                        var isPathExist = db.Dosyas.Any(x => x.DosyaYolu == path && x.Durumu != true);
                        if (isPathExist == true)
                        {
                            result.Message = "Bir veya birden fazla dosyanız zaten yuklu";
                        }
                        else
                        {
                            if (item.ContentLength < 0)
                            {
                                result.Message= "Dosyanız yuklenemedi";
                            }
                            Dosya dosya = new Dosya();
                            dosya.DosyaBoyutu = item.ContentLength;
                            dosya.DosyaTipi = Path.GetExtension(filename);
                            dosya.DosyaAdi = filename;
                            dosya.DosyaYolu = path;                           
                            dosya.KullaniciId = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
                            dosya.OlusturulmaZamani = DateTime.Now;
                            dosya.DosyaMi = true;
                            db.Dosyas.Add(dosya);
                            item.SaveAs(path);
                            result.Data = true;
                            result.Code = 1;
                            result.Message = "Başarılı bir şekilde yukleme tamamlandı";
                            db.SaveChanges();
                        }
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    result.Message = "Bir hata meydana geldi. Lütfen yükleme yapmayı tekrar deneyiniz.";
                }
            }
            return result;
        }
        public void DBSil(int DosyaId,Dosya dosya)
        {
            var dosya1 = dosya;
            var silinecekDosya = dosya1.DosyaYolu;
            dosya1.Durumu = true;
            System.IO.File.Delete(silinecekDosya);
            db.SaveChanges();
        }
        public void PaylasilanlarTB_Ekle(int DosyaId, string Adi, int PaylasilanKisi, int KimPaylasti,  int Yetki, string PaylasilaninYolu, int? PaylasilanlarinParentId, bool? DosyaMi)
        {
            Paylasilanlar paylas = new Paylasilanlar();
            paylas.DosyaId = DosyaId;
            paylas.Adi = Adi;
            paylas.PaylasilanKisi = PaylasilanKisi;
            paylas.KimPaylasti = KimPaylasti;
            paylas.PaylasilmaTarihi = DateTime.Now;
            paylas.Yetki = Yetki;
            paylas.PaylasilaninYolu = PaylasilaninYolu;
            paylas.PaylasilanlarinParentId = PaylasilanlarinParentId;
            paylas.DosyaMi = DosyaMi;
            db.Paylasilanlars.Add(paylas);
            db.SaveChanges();
        }
    }
}

