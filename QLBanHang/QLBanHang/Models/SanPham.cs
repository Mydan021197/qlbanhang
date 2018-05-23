namespace QLBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTDonMuas = new HashSet<CTDonMua>();
            CTPhieuNhaps = new HashSet<CTPhieuNhap>();
        }
        public SanPham(DataRow row)
        {
            Id = (int)row["id"];
            phai = (int)row["phai"];
            idHieu = (int)row["idHieu"];
            idDungLuong = (int)row["idDungLuong"];
            idNongDo = (int)row["idNongDo"];
            SLTon = (int)row["SLTon"];
            Sale = (int)row["Sale"];
            tensp = (string)row["tensp"];
            HinhAnh = (string)row["HinhAnh"];
            mota = (string)row["mota"];
            dvt = (string)row["dvt"];
        }
        public int Id { get; set; }
        [Required]
        public int phai { get; set; }
        public int? GiaBan { get; set; }
        public int idHieu { get; set; }
        public int idDungLuong { get; set; }
        public int idNongDo { get; set; }
        public double? Sale { get; set; }
        public int? SLTon { get; set; }
        public string HinhAnh { get; set; }
        public string mota { get; set; }
        public string tensp { get; set; }
        public string dvt { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonMua> CTDonMuas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuNhap> CTPhieuNhaps { get; set; }

        public virtual DungLuong DungLuong { get; set; }

        public virtual GioiTinh GioiTinh { get; set; }

        public virtual NhanHieu NhanHieu { get; set; }

        public virtual NongDo NongDo { get; set; }
    }
}
