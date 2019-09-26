namespace FileManageDAL.BusinessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActionFilter")]
    public partial class ActionFilter
    {
        [Key]
        public int Sira { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        [StringLength(50)]
        public string IpAdresi { get; set; }

        public string LinkNumaralari { get; set; }

        public DateTime? Tarih { get; set; }

        public int? KullaniciKim { get; set; }

        public string Bilgi { get; set; }
    }
}
