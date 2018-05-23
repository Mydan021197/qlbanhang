using QLBanHang.Areas.QuanLy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanHang.Areas.QuanLy.Controllers
{
    public class LoginController : Controller
    {
        Model1 db = new Model1();
        // GET: QuanLy/Login
        [HttpGet]
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string pass)
        {
          //  var tendn = collection["username"];
            //var matkhau = collection["pass"];
            if (String.IsNullOrEmpty(username))
            {
                ViewData["Loi1"] = "Phải nhập tên tài khoản";
            }
            else if (String.IsNullOrEmpty(pass))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {

                Admin ad = db.Admins.Where(x => x.Username == username && x.Pass == pass).FirstOrDefault();
                if (ad != null)
                {
                    Session["taikhoan"] = ad;
                    Session["hoten"] = ad.HoTen.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Thongbao = " Tên Đăng Nhập or Mật khẩu Không đúng...";
            }
            return View();


        }
    }
}