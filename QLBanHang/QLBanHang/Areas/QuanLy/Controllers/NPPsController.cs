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
    public class NPPsController : Controller
    {
        private Model1 db = new Model1();

        // GET: QuanLy/NPPs
        public ActionResult Index()
        {
            return View(db.NPPs.ToList());
        }

        // GET: QuanLy/NPPs/Details/5
      
        // GET: QuanLy/NPPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLy/NPPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenNPP")] NPP nPP)
        {
            if (ModelState.IsValid)
            {
                db.NPPs.Add(nPP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nPP);
        }

        // GET: QuanLy/NPPs/Edit/5
       

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
