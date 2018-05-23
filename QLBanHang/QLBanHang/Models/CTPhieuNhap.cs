namespace QLBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPhieuNhap")]
    public partial class CTPhieuNhap
    {
        public int Id { get; set; }

        public int idPN { get; set; }

        public int idSp { get; set; }

        public int giaNhap { get; set; }

        public int SLNhap { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
