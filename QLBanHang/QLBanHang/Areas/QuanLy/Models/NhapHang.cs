
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace QLBanHang.Areas.QuanLy.Models
{

    [Table("NhapHang")]
    public partial class NhapHang
    {
        public NhapHang()
        {
        }

        public List<CTPhieuNhap> ctphieu = new List<CTPhieuNhap>();

        public int Id { get; set; }

        public string tensp { get; set; }

        public int phai { get; set; }

        public string dvt { get; set; }

        public int? GiaBan { get; set; }

        public string HinhAnh { get; set; }

        public string mota { get; set; }

        public int idHieu { get; set; }

        public int idDungLuong { get; set; }

        public int idNongDo { get; set; }

        public int idNPP { get; set; }
        public int idNhanvien { get; set; }
        public int idCTphieuNhap { get; set; }
        public int idPN { get; set; }
        public int soluong { get; set; }

        public int gianhap { get; set; }
       


    }
}
