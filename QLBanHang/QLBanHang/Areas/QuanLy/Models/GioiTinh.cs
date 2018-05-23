namespace QLBanHang.Areas.QuanLy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("GioiTinh")]
    public partial class GioiTinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioiTinh()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int id { get; set; }

        [Column("GioiTinh")]
        [StringLength(10)]
        public string GioiTinh1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }

        public GioiTinh(DataRow data)
        {
            id = (int)data["id"];
            GioiTinh1 = data["GioiTinh"].ToString();
        }

    }
}
