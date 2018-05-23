using QLBanHang.Areas.QuanLy.Models;
using QLBanHang.Nhaphang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanHang.Areas.QuanLy.Controllers
{
    public class HomeController : Controller
    {
        ConnectClass cc = new ConnectClass();
        Model1 db = new Model1();
        // GET: QuanLy/Home
        public ActionResult Index()
        {
            var data = db.DatHangs.ToList();
            return View(data);
        }
        public ActionResult CTdathang(int id)
        {
            DatHang donhang = db.DatHangs.Find(id);
            chitietdonhangload result = new chitietdonhangload();
            result.dathang = donhang;
            result.ctdonmua = cc.chitietdonmua(id);
            return View(result);
        }
        public ActionResult Donhang()
        {
            var data = db.DatHangs.Where(s => s.TrangThai == 0).ToList();
            return View(data);
        }
        public ActionResult Duyet(int id)
        {
            Admin a = (Admin)Session["taikhoan"];
            DatHang dh = db.DatHangs.Find(id);

            dh.TenNV = a.HoTen;
            dh.TrangThai += 1;
            if (dh.TrangThai == 2)
            { dh.NgayGiaoHang = DateTime.Now; }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private int soLuongDH()
        {
            int SumSL = 0;
            SumSL = db.DatHangs.Count(s => s.TrangThai == 0);
            return SumSL;
        }
        public ActionResult DonhangPatial()
        {
            ViewBag.SoLuong = soLuongDH();
            return PartialView();
        }
        public ActionResult GiaoHang()
        {
            var data = db.DatHangs.Where(s => s.TrangThai == 1).ToList();
            return View(data);
        }
        private int slDHDangGiao()
        {
            int SumSL = 0;
            SumSL = db.DatHangs.Count(s => s.TrangThai == 1);
            return SumSL;
        }
        public ActionResult DanggiaoPatial()
        {
            ViewBag.sl = slDHDangGiao();
            return PartialView();
        }
        public ActionResult HoanThanh()
        {
            var data = db.DatHangs.Where(s => s.TrangThai == 2).ToList();
            return View(data);

        }

        private int slDHDaGiao()
        {
            int SumSL = 0;
            SumSL = db.DatHangs.Count(s => s.TrangThai == 2);
            return SumSL;
        }
        public ActionResult HoanThanhPatial()
        {
            ViewBag.soluong = slDHDaGiao();
            return PartialView();
        }
        public ActionResult XoaDH(int id)
        {
            if (DataProvider.Instance.ExcuteNonQuery("pXoaDonHang @idDonHang", new object[] { id }) >0)
                return RedirectToAction("Index");
            return View();
        }


        public ActionResult DonHangdaxoa()
        {
            return View(db.DONHANGDAXOAs.ToList());
        }
        private int slDHHuy()
        {
            int SumSL = 0;
            SumSL = db.DONHANGDAXOAs.Count();
            return SumSL;
        }
        public ActionResult HuyDH()
        {
            ViewBag.slhuy = slDHHuy();
            return PartialView();
        }




    }
}