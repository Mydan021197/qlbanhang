namespace QLBanHang.Areas.QuanLy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("DungLuong")]
    public partial class DungLuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DungLuong()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int Id { get; set; }

        [Required]
        public string DungTich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }

        public DungLuong(DataRow dt)
        {
            Id = (int)dt["Id"];
            DungTich = dt["DungTich"].ToString();
        }
    }
}
