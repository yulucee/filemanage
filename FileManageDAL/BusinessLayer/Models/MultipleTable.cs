using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileManageDAL.BusinessLayer.Entities;

namespace FileManageDAL.Models
{
    public class MultipleTable
    {
        public IEnumerable<Dosya> dosyalar { get; set; }
        public IEnumerable<Paylasilanlar> paylasilanlar { get; set; }
        public IEnumerable<Kullanici> kullanicilar { get; set; }

    }
}