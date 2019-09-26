namespace FileManageDAL.BusinessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mail")]
    public partial class Mail
    {
        public string MailAdresi { get; set; }

        public string Guid { get; set; }

        public DateTime? Tarih { get; set; }

        [StringLength(50)]
        public string ip { get; set; }

        public bool? Result { get; set; }

        public int id { get; set; }
    }
}
