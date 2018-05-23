namespace QLBanHang.Areas.QuanLy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("CTPhieuNhap")]
    public partial class CTPhieuNhap
    {
        public int Id { get; set; }

        public int idSp { get; set; }

        public int? IdPN { get; set; }

        public int? GiaNhap { get; set; }

        public int? GiaBan { get; set; }

        public int SLNhap { get; set; }

       // public string  TenSP { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual SanPham SanPham { get; set; }
        public CTPhieuNhap() { }
        public CTPhieuNhap(DataRow row)
        {
            Id = (int)row["ID"];
            idSp = (int)row["IDSP"];
            IdPN = (int)row["IDPN"];
            GiaNhap = (int)row["GiaNhap"];
            GiaBan = (int)row["GiaBan"];
            SLNhap = (int)row["SLNhap"];
            
        }
    }
}
