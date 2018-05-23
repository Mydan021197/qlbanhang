namespace QLBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatHang")]
    public partial class DatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatHang()
        {
            CTDonMuas = new HashSet<CTDonMua>();
        }

        public int Id { get; set; }

        public int idKH { get; set; }

        public DateTime NgayMua { get; set; }

        public int TongTien { get; set; }

        public DateTime NgayGiaoHang { get; set; }

        [Required]
        public string DiachiGiaoHang { get; set; }

        public int? TrangThai { get; set; }

        public string TenNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonMua> CTDonMuas { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
