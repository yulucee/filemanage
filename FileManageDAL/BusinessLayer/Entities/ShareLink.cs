namespace FileManageDAL.BusinessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShareLink")]
    public partial class ShareLink
    {
        public int Id { get; set; }

        public int? DosyaId { get; set; }

        public string DosyaAdi { get; set; }

        public bool? DosyaMi { get; set; }

        public int? PaylastigimKisiler { get; set; }

        public string Guid { get; set; }

        public int? ToplamOnizleme { get; set; }

        public bool? Durumu { get; set; }

        public bool? Global { get; set; }

        public DateTime? YaratilmaZamani { get; set; }
    }
}
