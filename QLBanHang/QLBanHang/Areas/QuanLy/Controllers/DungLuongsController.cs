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
    public class DungLuongsController : Controller
    {
        private Model1 db = new Model1();

        // GET: QuanLy/DungLuongs
        public ActionResult Index()
        {
            return View(db.DungLuongs.ToList());
        }
        // GET: QuanLy/DungLuongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLy/DungLuongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DungTich")] DungLuong dungLuong)
        {
            if (ModelState.IsValid)
            {
                db.DungLuongs.Add(dungLuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dungLuong);
        }

        // GET: QuanLy/DungLuongs/Edit/5
    

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
