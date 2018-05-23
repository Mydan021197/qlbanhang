namespace QLBanHang.Areas.QuanLy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("CTDonMua")]
    public partial class CTDonMua
    {
        
        public int Id { get; set; }

        public int idDH { get; set; }

        public int idSp { get; set; }

        public int SoLuong { get; set; }
        // đơi tí

        public int giaBan { get; set; }

        public int? ThanhTien { get; set; }
     

        public virtual DatHang DatHang { get; set; }

        public virtual SanPham SanPham { get; set; }
        public CTDonMua() { }
        public CTDonMua(DataRow row)
        {
            Id = (int)row["ID"];
            idDH = (int)row["idDH"];
            idSp= (int)row["idSP"];
            SoLuong = (int)row["SoLuong"];
            giaBan = (int)row["giaBan"];
            ThanhTien = (int)row["ThanhTien"];
        
        }
    }
}
