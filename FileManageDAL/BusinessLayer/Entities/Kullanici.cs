namespace FileManageDAL.BusinessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            Dosyas = new HashSet<Dosya>();
            Paylasilanlars = new HashSet<Paylasilanlar>();
        }

        public int KullaniciId { get; set; }

        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [StringLength(50)]
        public string KullaniciSoyadi { get; set; }

        public string KullaniciMaili { get; set; }

        public string KullaniciSifresi { get; set; }

        public string Guid { get; set; }

        public int? YetkiId { get; set; }

        public int? KimEkledi { get; set; }

        public long? TC { get; set; }

        public int? DogumYili { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dosya> Dosyas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paylasilanlar> Paylasilanlars { get; set; }
    }
}
