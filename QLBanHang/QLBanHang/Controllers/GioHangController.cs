using QLBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanHang.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang

        Model1 db = new Model1();

        public int Giohang { get; private set; }

        public ActionResult Index()
        {
            return View();
        }
        public List<GioHang> laygiohang()
        {
            List<GioHang> lstGioHang = Session["Giohang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["Giohang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult Themgiohang(int idSP, string strURL)
        {
            List<GioHang> lstGiohang = laygiohang();
            GioHang sp = lstGiohang.Find(n => n.idSP == idSP);
            if (sp == null)
            {
                sp = new GioHang(idSP);
                lstGiohang.Add(sp);
                return Redirect("GioHang");
            }
            else
            {
                    sp.soLuong++;
                    return Redirect("GioHang");
             }
          

        }
        private int TongSL()
        {
            int iSumSL = 0;
            List<GioHang> lstGioHang = Session["Giohang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iSumSL = lstGioHang.Sum(n => n.soLuong);

            } return iSumSL;
        }
        private int Tongtien()
        {
            int tSum = 0;
            List<GioHang> lstGioHang = Session["Giohang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tSum = lstGioHang.Sum(n => n.sthanhtien);

            }
            return tSum;
        }
        public ActionResult GioHang()
        {
            List<GioHang> lstGioHang = laygiohang();
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            ViewBag.SumSL = TongSL();
            ViewBag.Sum = Tongtien();
            return View(lstGioHang);

        }
        public ActionResult GiohangPartial()
        {
            ViewBag.SumSL = TongSL();
            ViewBag.Sum = Tongtien();
            return PartialView();

        }
        public ActionResult XoaGiohang(int idSP)
        {
            List<GioHang> lstGiohang = laygiohang();
            GioHang sp = lstGiohang.SingleOrDefault(n => n.idSP == idSP);
            if (sp != null)
            {
                lstGiohang.RemoveAll(n => n.idSP == idSP);
                return RedirectToAction("GioHang","GioHang");

            }
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            return RedirectToAction("GioHang","GioHang");

        }
        public ActionResult XoatatcaGioHang()
        {
            List<GioHang> lstgiohang = laygiohang();
            lstgiohang.Clear();
            return RedirectToAction("Index", "TrangChu");
        }
        

        public ActionResult Capnhatgiohang(int iMasp, FormCollection f)
        {
            List<GioHang> lstGiohang = laygiohang();
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.idSP == iMasp);
            if (sanpham != null)
            {
                sanpham.soLuong = int.Parse(f["txtSoluong"]);
            }

            return RedirectToAction("GioHang", "GioHang");
        }
    [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["TaikhoanKH"] == null || Session["TaikhoanKH"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            List<GioHang> lstGiohang = laygiohang();
            ViewBag.SumSL = TongSL();
            ViewBag.Sum = Tongtien();
            return PartialView(lstGiohang);
        }
        [HttpPost]
        public ActionResult DatHang(FormCollection collection)
        {
            List<GioHang> lstgiohang = laygiohang();
            DatHang dh = new DatHang();
            KhachHang kh = (KhachHang)Session["TaiKhoanKH"];
            dh.idKH = kh.Id;
            dh.NgayMua = DateTime.Now;
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["Ngaygiao"]);
            dh.NgayGiaoHang = DateTime.Parse(ngaygiao);
            var diachigiaohang = collection["DiaChiGiao"];
            dh.TongTien = Tongtien();
            dh.DiachiGiaoHang = diachigiaohang;
            dh.TrangThai = 0;
            
            db.DatHangs.Add(dh);
            db.SaveChanges();
            foreach (var item in lstgiohang)
            {
                CTDonMua ctdm = new CTDonMua();
                ctdm.idDH = dh.Id;
                ctdm.idSp = item.idSP;
                ctdm.SoLuong = item.soLuong;
                ctdm.giaBan = item.gia;
                ctdm.ThanhTien = item.sthanhtien;
                db.CTDonMuas.Add(ctdm);
            }
            db.SaveChanges();
            Session["Giohang"] = null;
            return RedirectToAction("Xacnhandonhang", "GioHang");
        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
    }

}