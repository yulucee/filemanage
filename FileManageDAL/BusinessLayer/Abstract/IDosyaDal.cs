using FileManageDAL.BusinessLayer.Entities;
using FileManageDAL.BusinessLayer.Models;
using FileManageDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManageDAL.BusinessLayer.Abstract
{
    public interface IDosyaDal
    {
        void DBSil(int DosyaId, Dosya dosya);
        void PaylasilanlarTB_Ekle(int DosyaId,string Adi,int PaylasilanKisi,int KimPaylasti,int Yetki,string PaylasilaninYolu,int? PaylasilanlarinParentId,bool? DosyaMi);
        ServiceResult DosyaYukle(DosyaYukleme yuklenecekDosya);
        ServiceResult Edits(int DosyaId,string DosyaAdi);
        ServiceResult Sil(int DosyaId);
        ServiceResult IcShare(string DosyaId, string KullaniciId, string Checked);

    }
}
