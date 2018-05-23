namespace QLBanHang.Areas.QuanLy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhap")]
    public partial class PhieuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhap()
        {
            
        }

        public int id { get; set; }

        public int? IdNPP { get; set; }

       // public string npp { get; set; }
        public DateTime? NgayNhap { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuNhap> CTPhieuNhaps { get; set; }

        public virtual NPP NPP { get; set; }
        public PhieuNhap(DataRow dt)
        {
            id = (int)dt["Id"];
            IdNPP = (int)dt["IdNPP"];
            NgayNhap = (DateTime)dt["NgayNhap"];
            TenNV = dt["TenNV"].ToString();
        }
    }
}
