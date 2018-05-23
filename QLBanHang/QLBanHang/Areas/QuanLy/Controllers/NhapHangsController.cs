using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Areas.QuanLy.Models;
using QLBanHang.Nhaphang;


namespace QLBanHang.Areas.QuanLy.Controllers
{
    public class NhapHangsController : Controller
    {
        private Model1 db = new Model1();
        ConnectClass cc = new ConnectClass();
        // GET: QuanLy/NhapHangs
        
        [HttpGet]
        public ActionResult CreatePN()
        {
            ViewBag.var1 = new SelectList(cc.LoadNPP(), "Id", "TenNPP");
            return View();
        }
        [HttpPost]
        public ActionResult CreatePN(FormCollection collect, PhieuNhap pn)
        {
            Admin ad = (Admin)Session["taikhoan"];
            ViewBag.var1 = new SelectList(cc.LoadNPP(), "Id", "TenNPP");
            int npp;
            int.TryParse(collect["var1"], out npp);

            if (cc.create(npp, ad.HoTen))
            {
                int idpn = (int)DataProvider.Instance.ExcuteScalar("select max(ID) from dbo.PhieuNhap");
                return RedirectToAction("CTphieunhap", new { id = idpn });
            }
            return View("phieunhap");
        }

        public ActionResult phieunhap()
        {
            return View(db.PhieuNhaps.ToList());
        }

        public ActionResult CTphieunhap(int id) /// Gửi Id của pheies qua đây
        {
            PhieuNhap phieu = db.PhieuNhaps.Find(id);
            ChiTietPhieuLoad result = new ChiTietPhieuLoad();
            result.phieunhap = phieu;
            result.dsPhieu = cc.GetListCTPhieuNhap(id);
            return View(result);
        }
   
        public ActionResult CreateNhapHang (int id)
        {
            ViewBag.nhanhieuu = new SelectList(cc.LoadNhanHieu(), "ID", "TenHieu");
            ViewBag.gioitinhh = new SelectList(cc.LoadGioiTinh(), "id", "GioiTinh1");
            ViewBag.nongdoo = new SelectList(cc.LoadNongdo(), "Id", "nongdo1");
            ViewBag.dungluong = new SelectList(cc.LoadDungluong(), "Id", "DungTich");
            ViewBag.nhanvien = new SelectList(cc.LoadNhanvien(), "Id", "HoTen");
            NhapHang ct = new NhapHang();
            ct.idPN = id;
            return View(ct);
        }
        [HttpPost]
        public ActionResult CreateNhapHang(FormCollection collection, NhapHang nhapHang, HttpPostedFileBase fileupload)
        {
            if(ModelState.IsValid)
            {
                if (fileupload == null)
                {
                    ViewBag.Thongbao = "Vui long Chọn ảnh";
                    return View();
                }
                var filename = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/Asset/images"), filename);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Thongbao = "Hinh anh da ton tai !";
                }
                else
                {
                    fileupload.SaveAs(path);
                }
                int nhanhieu, gioiTinh, nongdoo, dungluong, npp, nhanvien;
                int.TryParse(collection["nhanhieuu"], out nhanhieu);
                int.TryParse(collection["gioitinhh"], out gioiTinh);
                int.TryParse(collection["nongdoo"], out nongdoo);
                int.TryParse(collection["dungluong"], out dungluong);
                int.TryParse(collection["npp"], out npp);
                int.TryParse(collection["nhanvien"], out nhanvien);
                nhapHang.idDungLuong = dungluong;
                nhapHang.idHieu = nhanhieu;
                nhapHang.idNongDo = nongdoo;
                nhapHang.idNPP = npp;
                nhapHang.phai = gioiTinh;
                nhapHang.idNhanvien = nhanvien;
                nhapHang.HinhAnh = filename;

                if (cc.CreateSP(nhapHang))
                {

                    return RedirectToAction("CTphieunhap", new { id = nhapHang.Id });
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi thêm");
                }
                
            }
            ViewBag.nhanhieuu = new SelectList(cc.LoadNhanHieu(), "ID", "TenHieu");
            ViewBag.gioitinhh = new SelectList(cc.LoadGioiTinh(), "id", "GioiTinh1");
            ViewBag.nongdoo = new SelectList(cc.LoadNongdo(), "Id", "nongdo1");
            ViewBag.dungluong = new SelectList(cc.LoadDungluong(), "Id", "DungTich");
            ViewBag.npp = new SelectList(cc.LoadNPP(), "Id", "TenNPP");
            ViewBag.nhanvien = new SelectList(cc.LoadNhanvien(), "Id", "HoTen");

            return View("Index", "SanPhams");

        
        }
    }
}
