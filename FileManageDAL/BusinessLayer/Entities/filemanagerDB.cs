namespace FileManageDAL.BusinessLayer.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Common;

    public partial class filemanagerDB : DbContext
    {
        public filemanagerDB()
            : base("name=filemanagerDB")
        {
        }
        public filemanagerDB(string connectionString) : base(connectionString) { }
        public filemanagerDB(DbConnection connection) : base(connection, true) { }
        public virtual DbSet<ActionFilter> ActionFilters { get; set; }
        public virtual DbSet<Dosya> Dosyas { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Mail> Mails { get; set; }
        public virtual DbSet<Paylasilanlar> Paylasilanlars { get; set; }
        public virtual DbSet<ShareLink> ShareLinks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Paylasilanlars)
                .WithOptional(e => e.Kullanici)
                .HasForeignKey(e => e.PaylasilanKisi);
        }
    }
}
