namespace QLBanHang.Areas.QuanLy.Models
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
            Id = (int)row["Id"];
            tensp = row["tensp"].ToString();
            phai = (int)row["phai"];
            dvt = row["dvt"].ToString();
            GiaBan = (int)row["GiaBan"];
            HinhAnh = row["HinhAnh"].ToString();
            mota = row["mota"].ToString();
            idHieu = (int)row["idHieu"];
            idNongDo = (int)row["idNongDo"];
            idDungLuong = (int)row["idDungLuong"];
            double tam;
            double.TryParse(row["Sale"].ToString(), out tam);
            Sale = tam;
            SLTon = (int)row["SLTon"];

        }

        public int Id { get; set; }
        
        [Required]
        public string tensp { get; set; }

        public int phai { get; set; }

        public string dvt { get; set; }

        public int? GiaBan { get; set; }

        public string HinhAnh { get; set; }

        public string mota { get; set; }

        public int idHieu { get; set; }

        public int idDungLuong { get; set; }

        public int idNongDo { get; set; }

        public double? Sale { get; set; }

        public int? SLTon { get; set; }

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
