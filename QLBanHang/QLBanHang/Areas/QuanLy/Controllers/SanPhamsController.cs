using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;
using QLBanHang.sanpham;

namespace QLBanHang.Areas.QuanLy.Controllers
{
    public class SanPhamsController : Controller
    {
        ConnectClass cc = new ConnectClass();
        private Model1 db = new Model1();

        // GET: SanPhams
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.DungLuong).Include(s => s.NhanHieu).Include(s => s.NongDo);
            return View(sanPhams.ToList());
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

    
        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            ViewBag.phai = new SelectList(db.GioiTinhs, "id", "GioiTinh1", sanPham.phai);

            ViewBag.idDungLuong = new SelectList(db.DungLuongs, "Id", "DungTich", sanPham.idDungLuong);
            ViewBag.idHieu = new SelectList(db.NhanHieux, "Id", "TenHieu", sanPham.idHieu);
            ViewBag.idNongDo = new SelectList(db.NongDoes, "Id", "nongdo1", sanPham.idNongDo);
            return View(sanPham);
        }
        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection,int id, SanPham sanPham,HttpPostedFileBase fileupload)
        {
        
            var a = collection["tensp"];
            var b = collection["phai"];
            int b1;
            int.TryParse(b, out b1);
            var c = collection["dvt"];
            var d = collection["GiaBan"];
            int d1;
            int.TryParse(d, out d1);
            var e = collection["mota"];
            var f = collection["idHieu"];
            var g = collection["idDungLuong"];
            var h = collection["idNongDo"];

            ///
            if (fileupload != null && sanPham.HinhAnh != fileupload.FileName )
            {
                var filename = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/images/"), filename);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Thongbao = "Hinh anh da ton tai !";
                }
                else
                {   
                    fileupload.SaveAs(path);

                }
                sanPham.HinhAnh = fileupload.FileName;
            }
            if (cc.edit(id,a, b1, c, d1, e, f, g, h,sanPham.HinhAnh))
            {
                return RedirectToAction("Index");
            }

            ViewBag.phai = new SelectList(db.GioiTinhs, "id", "GioiTinh1", sanPham.phai);
            ViewBag.idDungLuong = new SelectList(db.DungLuongs, "Id", "DungTich", sanPham.idDungLuong);
            ViewBag.idHieu = new SelectList(db.NhanHieux, "Id", "TenHieu", sanPham.idHieu);
            ViewBag.idNongDo = new SelectList(db.NongDoes, "Id", "nongdo1", sanPham.idNongDo);
            return View();
        }

        // GET: SanPhams/Delete/5
       
    }
}
