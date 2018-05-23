using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Areas.QuanLy.Models;
using QLBanHang.khachHang;

namespace QLBanHang.Areas.QuanLy.Controllers
{
    public class KhachHangs1Controller : Controller
    {
        ConnectClass cc = new ConnectClass();
        private Model1 db = new Model1();

        // GET: QuanLy/KhachHangs1
        public ActionResult Index()
        {
            return View(db.KhachHangs.ToList());
        }

        // GET: QuanLy/KhachHangs1/Details/5
     

        // GET: QuanLy/KhachHangs1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLy/KhachHangs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Hoten,Sdt,DiaChi,phai,tenDN,pass")] KhachHang khachHang)
        {
            if (cc.create(khachHang))
            {
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: QuanLy/KhachHangs1/Edit/5
 
        // GET: QuanLy/KhachHangs1/Delete/5
     

   
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
