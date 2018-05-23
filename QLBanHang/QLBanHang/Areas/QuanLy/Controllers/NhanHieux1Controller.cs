using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Areas.QuanLy.Models;

namespace QLBanHang.Areas.QuanLy.Controllers
{
    public class NhanHieux1Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: QuanLy/NhanHieux1
        public ActionResult Index()
        {
            return View(db.NhanHieux.ToList());
        }

        // GET: QuanLy/NhanHieux1/Details/5
       
        // GET: QuanLy/NhanHieux1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLy/NhanHieux1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenHieu")] NhanHieu nhanHieu)
        {
            if (ModelState.IsValid)
            {
                db.NhanHieux.Add(nhanHieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhanHieu);
        }

        // GET: QuanLy/NhanHieux1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanHieu nhanHieu = db.NhanHieux.Find(id);
            if (nhanHieu == null)
            {
                return HttpNotFound();
            }
            return View(nhanHieu);
        }

        // POST: QuanLy/NhanHieux1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenHieu")] NhanHieu nhanHieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanHieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanHieu);
        }

        // GET: QuanLy/NhanHieux1/Delete/5
     

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
