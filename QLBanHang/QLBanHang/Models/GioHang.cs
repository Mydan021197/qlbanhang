using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using QLBanHang.Models;

namespace QLBanHang.Models
{
    public class GioHang
    {
        Model1 db = new Model1();
        public int idSP { set; get; }
        public string tenSp { set; get; }
        public string hinhsp { get; set; }
        public int soLuong { get; set; }
        public int gia { get; set; }
        public double sale { get; set; }
        public int sthanhtien
        {
            get { return (soLuong * gia - (int)((soLuong * gia)*sale / 100)); }
        }
        public GioHang(int Masp)
        {
            idSP = Masp;
            SanPham sp = db.SanPhams.Single(n => n.Id == idSP);
            tenSp = sp.tensp;
            hinhsp = sp.HinhAnh;
            gia = int.Parse(sp.GiaBan.ToString());
            soLuong = 1;
            sale = double.Parse(sp.Sale.ToString());
        }
    }

}