namespace FileManageDAL.BusinessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Paylasilanlar")]
    public partial class Paylasilanlar
    {
        [Key]
        public int ToplamPaylasmaId { get; set; }

        public int? DosyaId { get; set; }

        public string Adi { get; set; }

        public int? PaylasilanKisi { get; set; }

        public int? KimPaylasti { get; set; }

        public DateTime? PaylasilmaTarihi { get; set; }

        public bool? Durumu { get; set; }

        public int? Yetki { get; set; }

        public string PaylasilaninYolu { get; set; }

        public int? PaylasilanlarinParentId { get; set; }

        public bool? DosyaMi { get; set; }

        public virtual Dosya Dosya { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
