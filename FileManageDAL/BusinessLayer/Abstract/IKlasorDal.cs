using FileManageDAL.BusinessLayer.Models;
using FileManageDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManageDAL.BusinessLayer.Abstract
{
    public interface IKlasorDal
    {
        void ShareLinkTB_Ekle(int DosyaId, string DosyaAdi, bool? DosyaMi, int? PaylastigimKisiler,string Guid, int? ToplamOnizleme, bool? Durumu, bool? Global);
        void PaylasilanlarTB_Ekle(int DosyaId, string Adi, int PaylasilanKisi, int KimPaylasti, int Yetki, string PaylasilaninYolu, int? PaylasilanlarinParentId, bool? DosyaMi);
        void DosyaTB_Ekle(string DosyaYolu, int? DosyaBoyutu, string DosyaTipi, string DosyaAdi, int? ParentId, int KullaniciId, bool? DosyaMi);
        ServiceResult AnaSayfa(int? id);
        ServiceResult Sil(int KlasorId);
        ServiceResult Edits(int DosyaId, string KlasorAdi);
        ServiceResult Creates(string YeniKlasorAdi);
        ServiceResult KlasorAc(int? id);
        ServiceResult CreateInFolder(string YeniKlasorAdi, int EskiKlasorId);
        ServiceResult RenameINFolder(string KlasorAdi, int EskiKlasorId, int KlasorId);
        ServiceResult DeleteINFolder(int KlasorId, int EskiKlasorId);
        ServiceResult DosyaINYukle(DosyaYukleme yuklenecekDosya, int klasorId);
        ServiceResult DosyaINDelete(int DosyaId);
        ServiceResult DosyaINRename(int DosyaId, string DosyaAdi, int EskiKlasorId);
        ServiceResult CokluDownload(string DosyaId);
        ServiceResult KlasorDosyaDownload(string IDs);
        ServiceResult PaylasilanlariTopluIndirme(string IDs);
        ServiceResult KlasorIciDosyaDownload(string IDs);
        ServiceResult KlasorDownload(int KlasorId);
        ServiceResult DosyaDownload(int DosyaId);
        ServiceResult VideoPlayer(int DosyaId);
        ServiceResult FileCut(string Dosyaid);
        ServiceResult FilePaste(int DosyaId,string tempdosyaid);
        ServiceResult Info(int id);
        ServiceResult YetkiDegisikligiAjax(Dictionary<String, Gift> myDictionary, int KlasorDosyaId);
        ServiceResult LinkPaylas(string DosyaId);
        ServiceResult ShareWithLink(string code);
        ServiceResult PaylastigimLinkler();
        ServiceResult LinkKapat2(int DosyaId, int Checked);
    }
}
