namespace FileManageDAL.BusinessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dosya")]
    public partial class Dosya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dosya()
        {
            Paylasilanlars = new HashSet<Paylasilanlar>();
        }
        public int DosyaId { get; set; }
        public string DosyaYolu { get; set; }
        public int? DosyaBoyutu { get; set; }
        [StringLength(20)]
        public string DosyaTipi { get; set; }

        public DateTime? OlusturulmaZamani { get; set; }

        public string DosyaAdi { get; set; }

        public int? ParentId { get; set; }

        public int? KullaniciId { get; set; }

        public bool? Durumu { get; set; }

        public bool? DosyaMi { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paylasilanlar> Paylasilanlars { get; set; }
    }
}
