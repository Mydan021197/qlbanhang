namespace QLBanHang.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CTDonMua> CTDonMuas { get; set; }
        public virtual DbSet<CTPhieuNhap> CTPhieuNhaps { get; set; }
        public virtual DbSet<DatHang> DatHangs { get; set; }
        public virtual DbSet<DungLuong> DungLuongs { get; set; }
        public virtual DbSet<GioiTinh> GioiTinhs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanHieu> NhanHieux { get; set; }
        public virtual DbSet<NongDo> NongDoes { get; set; }
        public virtual DbSet<NPP> NPPs { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.Pass)
                .IsFixedLength();

            modelBuilder.Entity<DatHang>()
                .HasMany(e => e.CTDonMuas)
                .WithRequired(e => e.DatHang)
                .HasForeignKey(e => e.idDH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DungLuong>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.DungLuong)
                .HasForeignKey(e => e.idDungLuong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GioiTinh>()
                .Property(e => e.GioiTinh1)
                .IsFixedLength();

            modelBuilder.Entity<GioiTinh>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.GioiTinh)
                .HasForeignKey(e => e.phai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DatHangs)
                .WithRequired(e => e.KhachHang)
                .HasForeignKey(e => e.idKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanHieu>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.NhanHieu)
                .HasForeignKey(e => e.idHieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NongDo>()
                .Property(e => e.nongdo1)
                .IsFixedLength();

            modelBuilder.Entity<NongDo>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.NongDo)
                .HasForeignKey(e => e.idNongDo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NPP>()
                .HasMany(e => e.PhieuNhaps)
                .WithRequired(e => e.NPP)
                .HasForeignKey(e => e.idNPP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.CTPhieuNhaps)
                .WithRequired(e => e.PhieuNhap)
                .HasForeignKey(e => e.idPN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTDonMuas)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.idSp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTPhieuNhaps)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.idSp)
                .WillCascadeOnDelete(false);
        }
    }
}
