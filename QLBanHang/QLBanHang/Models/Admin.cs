namespace QLBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public int id { get; set; }

        [StringLength(20)]
        public string Username { get; set; }

        [StringLength(20)]
        public string Pass { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        public int? ChucVu { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }
    }
}
