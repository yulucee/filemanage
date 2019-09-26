using FileManageDAL.BusinessLayer.Models;
using FileManageDAL.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManageDAL.Models;

namespace FileManageDAL.BusinessLayer.Abstract
{
    public interface IPaylasilanlarDal
    {
        void DosyaTB_Ekle(string DosyaYolu, int DosyaBoyutu, string DosyaTipi, string DosyaAdi, int ParentId, int KullaniciId,bool DosyaMi);
        void PaylasilanlarTB_Ekle(int DosyaId, string Adi, int PaylasilanKisi, int KimPaylasti, int Yetki, string PaylasilaninYolu, int? PaylasilanlarinParentId, bool DosyaMi);
        ServiceResult Index(int? id);
        ServiceResult PaylasilanlariAc(int? id);
        ServiceResult Paylastiklarim(int? id);
        ServiceResult PaylastiklarimiAc(int? id);
        ServiceResult Bilgi(string id);
        ServiceResult BenimlePaylasilanlarBilgi(string id);
        ServiceResult PaylasilanaEkle(DosyaYukleme yuklenecekDosya, int klasorId);
        ServiceResult YetkiKaldirma(int? PaylasmaId);
    }
}
