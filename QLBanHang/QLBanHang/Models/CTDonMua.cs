namespace QLBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDonMua")]
    public partial class CTDonMua
    {
        public int Id { get; set; }

        public int idDH { get; set; }

        public int idSp { get; set; }

        public int SoLuong { get; set; }

        public int giaBan { get; set; }

        public int? ThanhTien { get; set; }

        public virtual DatHang DatHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
