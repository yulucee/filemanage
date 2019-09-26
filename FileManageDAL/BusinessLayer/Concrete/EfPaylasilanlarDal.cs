using FileManageDAL.BusinessLayer.Abstract;
using FileManageDAL.BusinessLayer.Entities;
using FileManageDAL.BusinessLayer.Models;
using FileManageDAL.Common;
using FileManageDAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FileManageDAL.BusinessLayer.Concrete
{
    public class EfPaylasilanlarDal : IPaylasilanlarDal
    {
        private filemanagerDB db;
        public EfPaylasilanlarDal()
        {
            this.db = new filemanagerDB();
        }
        public ServiceResult Index(int? id)
        {
            ServiceResult result = new ServiceResult();
            var mymodel = new PaylasilanlarMultipleTable();
            var kullaniciid = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
            mymodel.paylasilanlar = db.Paylasilanlars.Where(m => m.PaylasilanKisi == kullaniciid && m.Durumu == null && m.PaylasilanlarinParentId == null).ToList();
            result.Data = mymodel;
            result.Code = 1;
            return result;
        }
        public ServiceResult PaylasilanlariAc(int? id)
        {
            ServiceResult result = new ServiceResult();
            var mymodel = new PaylasilanlarMultipleTable();
            var kullaniciid = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
            mymodel.paylasilanlar = db.Paylasilanlars.Where(m => m.PaylasilanKisi == kullaniciid && m.Durumu == null && m.PaylasilanlarinParentId == id).ToList();
            if (mymodel.paylasilanlar.Count() == 0)
            {
                result.Code = 0;
                result.Message = "Hiçbir sonuç bulunamadı";
            }
            else
            {
                result.Code = 1;
                result.Data = mymodel;
            }
            return result;
        }
        public ServiceResult Paylastiklarim(int? id)
        {
            ServiceResult result = new ServiceResult();
            var mymodel = new PaylasilanlarMultipleTable();
            var kullaniciid = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
            mymodel.paylasilanlar = db.Paylasilanlars.Where(m => m.KimPaylasti == kullaniciid && m.Durumu == null && m.PaylasilanlarinParentId == null).ToList();
            result.Code = 1;
            result.Data = mymodel;
            return result;
        }
        public ServiceResult PaylastiklarimiAc(int? id)
        {
            ServiceResult result = new ServiceResult();
            var mymodel = new PaylasilanlarMultipleTable();
            var kullaniciid = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
            mymodel.paylasilanlar = db.Paylasilanlars.Where(m => m.KimPaylasti == kullaniciid && m.Durumu == null && m.PaylasilanlarinParentId == id).ToList();
            result.Code = 1;
            result.Data = mymodel;
            return result;
        }
        public ServiceResult Bilgi(string id)
        {
            ServiceResult result = new ServiceResult();
            if (String.IsNullOrWhiteSpace(id) || id == "none")
            {
                result.Code = 0; 
                result.Data = "Bir dosya secimi yapılmadı!!! Lutfen bilgisini gormek istediginiz dosyayi seciniz..";
                return result;
            }
            string[] parcalar = ExtensionMethod.Parcala(id);
            var istedigimid = Convert.ToInt32(parcalar[0]);
            var kullaniciid = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
            var eris = db.Paylasilanlars.Where(m => m.DosyaId == istedigimid && m.Durumu == null && m.KimPaylasti == kullaniciid).ToList();
            var folderid = db.Paylasilanlars.Where(m => m.DosyaId == istedigimid && m.Durumu == null).Select(m => m.PaylasilanKisi).ToList();
            List<Kullanici> kullanicilar = db.Kullanicis.Where(x => folderid.Contains(x.KullaniciId)).ToList();
            List<string> kullanicilistesi = new List<string>();

            var sharetime = "";
            var yetki = "";
            for (int j = 0; j < eris.Count; j++)
            {
                sharetime = eris[j].PaylasilmaTarihi.ToString();
                yetki = eris[j].Yetki.ToString();
                if (yetki == "1")
                {
                    yetki = "Önizleme";
                }
                else if (yetki == "2")
                {
                    yetki = "İndirme";
                }
                else if (yetki == "3")
                {
                    yetki = "Önizleme & İndirme";
                }
                var kullaniciismi = eris[j].Kullanici.KullaniciAdi;
                kullanicilistesi.Add("<tr><td>" + kullaniciismi + "</td>" + "<td>" + sharetime + "</td>" + "<td>" + yetki + "</td>" + "</tr>");
            }
            result.Code = 1;
            result.Data = kullanicilistesi;
            return result;
        }
        public ServiceResult BenimlePaylasilanlarBilgi(string id)
        {
            ServiceResult result = new ServiceResult();
            if (String.IsNullOrWhiteSpace(id) || id == "none")
            {
                result.Code = 0; 
                result.Data = "Bir dosya secimi yapılmadı!!! Lutfen bilgisini gormek istediginiz dosyayi seciniz..";
                return result;
            }
            string[] parcalar = ExtensionMethod.Parcala(id);
            var adet = parcalar.Length;
            var kullaniciid = Convert.ToInt32(HttpContext.Current.Session["kullaniciId"]);
            var yetkiadi = "";
            List<string> kullaniciliste = new List<string>();
            for (int i=0; i <parcalar.Length; i++)
            {
                var istedigimid = Convert.ToInt32(parcalar[i]);
                var eris = db.Paylasilanlars.Where(m => m.DosyaId == istedigimid && m.Durumu == null && m.PaylasilanKisi == kullaniciid).SingleOrDefault();
                if(eris == null)
                {
                    result.Code = 4;
                    result.Message = "Hiç bir kayıt bulunamadı";
                    return result;
                }
                var dosyaismi = eris.Adi;
                var sharetime = eris.PaylasilmaTarihi;
                var yetki = Convert.ToInt32(eris.Yetki);
                if (yetki == 1)
                {
                    yetkiadi = "Önizleme";
                }
                else if (yetki == 2)
                {
                    yetkiadi = "İndirme";
                }
                else if (yetki == 3)
                {
                    yetkiadi = "Önizleme & İndirme";
                }
                var kullaniciismi = eris.Kullanici.KullaniciAdi;
                kullaniciliste.Add("<tr><td>" + kullaniciismi + "</td>"+"<td>"+ dosyaismi +"</td>"+"<td>" + sharetime + "</td>" + "<td>" + yetkiadi + "</td>" + "</tr>");
            }
            result.Code = 1;
            result.Data = kullaniciliste;
            return result;
        }
        public ServiceResult PaylasilanaEkle(DosyaYukleme yuklenecekDosya, int klasorId)
        {
            ServiceResult result = new ServiceResult();
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in yuklenecekDosya.Files)
                    {
                        var filename = Path.GetFileName(item.FileName);
                        var icindebulundugumklasorunid = klasorId;
                        var icindeoldugumklasorunpathi = db.Paylasilanlars.Where(x => x.DosyaId == klasorId).Select(x => x.PaylasilaninYolu).Single();
                        var path = icindeoldugumklasorunpathi + @"\" + filename;
                        var isPathExist = db.Dosyas.Any(x => x.DosyaYolu == path && x.Durumu != true);
                        if (isPathExist == true)
                        {
                            result.Code = 0; 
                            result.Data = "Aynı dosyadan var. Farklı bir dosya deneyiniz.";
                            return result;
                        }
                        else
                        {
                            if (item.ContentLength < 0)
                            {
                                result.Code = 1;
                                result.Data = "Oluşturulamadı";
                                return result;
                            }
                            Paylasilanlar paylas = db.Paylasilanlars.SingleOrDefault(x => x.DosyaId == klasorId);
                            var paylasilankisi = paylas.PaylasilanKisi;
                            var kimpaylasti = paylas.KimPaylasti;
                            var yetkiid = paylas.Yetki;
                            var paylasilaninyolu = paylas.PaylasilaninYolu;
                            var parentid = paylas.PaylasilanlarinParentId;
                            var icindeoldugumklasorunpathi1 = db.Dosyas.Where(x => x.DosyaId == klasorId && x.DosyaMi == null).Select(x => x.DosyaYolu).Single();
                            var path1 = icindeoldugumklasorunpathi1 + @"\" + filename;
                            DosyaTB_Ekle(path1, item.ContentLength, Path.GetExtension(filename), filename, klasorId, (int)kimpaylasti,true);
                            var dosyaid = db.Dosyas.Where(x => x.DosyaYolu == path1).Select(x => x.DosyaId).Single();
                            PaylasilanlarTB_Ekle(dosyaid, filename, (int)paylasilankisi, (int)kimpaylasti, (int)yetkiid, path, klasorId, true);
                            item.SaveAs(path);
                            item.SaveAs(path1);
                        }
                        transaction.Commit();
                        result.Code = 2;
                        result.Data = "Islem Basarili";
                        return result;
                    }
                }
                catch (Exception)
                {
                    result.Code = 3; 
                    result.Data = "Bir hata meydana geldi. Lütfen yükleme yapmayı tekrar deneyiniz.";
                    transaction.Rollback();
                    return result;
                }
                return result;
            }
        }
        public ServiceResult YetkiKaldirma(int? PaylasmaId) //Paylasma yapıldiktan sonra çıkan tekli sil butonu 
        {
            ServiceResult sonuc = new ServiceResult();
            if(PaylasmaId == null || PaylasmaId == 0)
            {
                sonuc.Code = 3;
                sonuc.Message = "Id Belirtilmemiş";
                return sonuc;
            }
            var id = PaylasmaId;
            var getir = db.Paylasilanlars.Where(x => x.ToplamPaylasmaId == PaylasmaId).SingleOrDefault();
            if(getir == null)
            {
                sonuc.Code = 4;
                sonuc.Message = "Belirtilen dosya bulunamadı";
                return sonuc;
            }
            var path = getir.PaylasilaninYolu;
            var silinecekkisi = getir.PaylasilanKisi;
            var silinecekaltklasorler = db.Paylasilanlars.Where(x => x.PaylasilaninYolu.Contains(path) && x.PaylasilanKisi == silinecekkisi).Select(x => x).ToList();
            if(silinecekaltklasorler == null)
            {
                sonuc.Code = 5;
                sonuc.Message = "Silinecek başka dosya kalmadı";
                return sonuc;
            }
            foreach (Paylasilanlar d in silinecekaltklasorler)
            {
                var kisi = d.PaylasilanKisi;
                var kisiadi = d.Kullanici.KullaniciAdi;
                var kisisoyadi = d.Kullanici.KullaniciSoyadi;
                var user = kisiadi + " " + kisisoyadi;
                d.Durumu = true;
                db.SaveChanges();
                sonuc.Code = 1;
                sonuc.Data = "<option class='fileshareoption " + silinecekkisi + "' value='" + silinecekkisi + "'>" + user + "</option>";
            }
            return sonuc;
        }
        public void PaylasilanlarTB_Ekle(int DosyaId, string Adi, int PaylasilanKisi, int KimPaylasti, int Yetki, string PaylasilaninYolu, int? PaylasilanlarinParentId, bool DosyaMi)
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
        public void DosyaTB_Ekle(string DosyaYolu, int DosyaBoyutu, string DosyaTipi, string DosyaAdi, int ParentId, int KullaniciId,bool DosyaMi)
        {
            Dosya dosya = new Dosya();
            dosya.DosyaBoyutu = DosyaBoyutu;
            dosya.DosyaTipi = DosyaTipi;
            dosya.DosyaAdi = DosyaAdi;
            dosya.DosyaYolu = DosyaYolu;
            dosya.KullaniciId = KullaniciId;
            dosya.OlusturulmaZamani = DateTime.Now;
            dosya.ParentId = ParentId;
            dosya.DosyaMi = DosyaMi;
            dosya.Durumu = null;
            db.Dosyas.Add(dosya);
            db.SaveChanges();
        }
    }
}
