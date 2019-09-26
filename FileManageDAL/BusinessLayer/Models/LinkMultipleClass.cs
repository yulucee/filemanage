using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileManageDAL.BusinessLayer.Entities;
namespace FileManageDAL.Models
{
    public class LinkMultipleClass
    {
        public IEnumerable<Kullanici> kullanicilar { get; set; }
        public IEnumerable<Dosya> dosyalar { get; set; }
        public IEnumerable<Paylasilanlar> paylasilanlar { get; set; }
        public IEnumerable<ShareLink> linkler { get; set; }
    }
}