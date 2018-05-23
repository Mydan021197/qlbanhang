using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;

namespace QLBanHang.Controllers
{
    public class NguoidungController : Controller
    {
        Model1 db = new Model1();
        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KhachHang khachhang)
        {
            var hoten = collection["Hoten"];
            var tendn = collection["username"];
            var pass = collection["pass"];
            var confirmpass = collection["confirm pass"];
            var dienthoai = collection["PhoneNumber"];
            var diachi = collection["DiaChi"];
          
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Không được bỏ trống họ tên --";
            }
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tài khoản --";
            }
            if (String.IsNullOrEmpty(pass))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu --";
            }
            if (String.IsNullOrEmpty(confirmpass))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu --";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi5"] = "Chưa nhập số điện thoại --";
            }

            if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi7"] = "Chưa nhập Địa CHỉ --";
            }
            else
            {
                khachhang.Hoten = hoten;
                khachhang.tenDN = tendn;
                khachhang.pass = pass;
                khachhang.Sdt = int.Parse(dienthoai);
                khachhang.DiaChi = diachi;
             
                db.KhachHangs.Add(khachhang);
                db.SaveChanges();
                return RedirectToAction("Dangnhap");
            }

            return this.Dangky();
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["pass"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên tài khoản";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
               KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.tenDN == tendn && n.pass == matkhau);
                if (kh != null)
                {
                    Session["TaikhoanKH"] = kh; 
                    Session["Taikhoan"] = kh.Hoten.ToString();
                    return RedirectToAction("Dathang", "GioHang");
                }
                else
                    ViewBag.Thongbao = " Tên Đăng Nhập or Mật khẩu Không đúng...";
            }
            return View();


        }

    }
}