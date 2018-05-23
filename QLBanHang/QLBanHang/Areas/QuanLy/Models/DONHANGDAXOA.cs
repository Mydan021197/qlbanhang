namespace QLBanHang.Areas.QuanLy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANGDAXOA")]
    public partial class DONHANGDAXOA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idKH { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime NgayMua { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TongTien { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime NgayGiaoHang { get; set; }

        [Key]
        [Column(Order = 5)]
        public string DiachiGiaoHang { get; set; }

        public string TenNV { get; set; }

        public DateTime? ngayXoa { get; set; }
    }
}
