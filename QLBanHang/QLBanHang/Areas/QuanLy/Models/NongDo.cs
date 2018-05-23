namespace QLBanHang.Areas.QuanLy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("NongDo")]
    public partial class NongDo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NongDo()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int Id { get; set; }

        [Column("nongdo")]
        [Required]
        [StringLength(50)]
        public string nongdo1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
        public NongDo(DataRow dt)
        {
            Id = (int)dt["Id"];
            nongdo1 = dt["nongdo"].ToString();
        }
    }
}
