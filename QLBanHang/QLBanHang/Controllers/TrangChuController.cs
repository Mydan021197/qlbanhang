using QLBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBanHang.sanpham;
using System.Data;

namespace QLBanHang.Controllers
{
    public class TrangChuController : Controller
    {
        ConnectClass cc = new ConnectClass();
        Model1 db = new Model1();

        // GET: TrangChu
        public ActionResult Index()
        {
            ViewBag.hieu = new SelectList(db.NhanHieux, "id", "tenhieu");
            return View();
        }
       
        public List<SanPham> Nuochoa(int count)
        {
            return db.SanPhams.Take(count).ToList();
        }
      
        
        public ActionResult Perfume(string SearchTerm)
        {


            var sp = from s in db.SanPhams select s;

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                sp = db.SanPhams.Where(s => s.tensp.Contains(SearchTerm));
            }
            ViewBag.SearchTerm = SearchTerm;

            return View(sp.ToList());
        }

        public ActionResult Details(int id)
        {



            var Loainchoa = from m in db.NhanHieux
                            from sp in db.SanPhams
                            where m.Id == sp.idHieu
                            where sp.Id == id
                            select m.TenHieu;
            ViewBag.HieuSP = Loainchoa.Single();

            var Nongdo = from nd in db.NongDoes
                            from sp in db.SanPhams
                            where nd.Id == sp.idNongDo
                            where sp.Id == id
                            select nd.nongdo1;
            ViewBag.Nongdo = Nongdo.Single();


            var Dungluong = from dl in db.DungLuongs
                            from sp in db.SanPhams
                            where dl.Id == sp.idDungLuong
                            where sp.Id == id
                            select dl.DungTich;
            ViewBag.Dungluong = Dungluong.Single();

            var GTinh = from gt in db.GioiTinhs
                            from sp in db.SanPhams
                            where gt.id == sp.phai
                            where sp.Id == id
                            select gt.GioiTinh1;
            ViewBag.Gioitinh = GTinh.Single();


            
            var nchoa = from n in db.SanPhams
                        where n.Id == id
                        select n;
            return View(nchoa.Single());    
        }
        
        public ActionResult BestSeller()
        {

            ViewBag.hieu = new SelectList(db.NhanHieux, "id", "tenhieu");
            var moi = Nuochoa(15);
            return View(moi);
        }
        //[HttpPost]
        //public ActionResult BestSeller(FormCollection collection)
        //{
        //    Test t = new Test();
        //    if (ModelState.IsValid)
        //    {
        //        int idhieu;
        //        ViewBag.hieu = new SelectList(db.NhanHieux, "id", "tenhieu");
        //        int.TryParse(collection["hieu"], out idhieu);
        //        t = new Test(idhieu);
        //        return View(t);

        //    }
        //    return View();
        //}
        // tim kím theo tên sản phẩm bằng ajax
        public JsonResult dsSP(string search)
        {
            List<SanPham> listSP = new List<SanPham>();
            List<SanPham> spp = db.SanPhams.Where(x => x.tensp.Contains(search) /*|| x.NhanHieu.TenHieu.Contains(search)*/).ToList();

            for (int i = 0; i < spp.Count(); i++)
            {
                SanPham s = new SanPham();
                s.Id = spp[i].Id;
                s.tensp = spp[i].tensp;
                //s.NhanHieu.Id = spp[i].NhanHieu.Id;
                listSP.Add(s);
            }
            return Json(listSP, JsonRequestBehavior.AllowGet);
        }
        // tìm kiếm theo Hiệu Sản Phẩm
        public ActionResult Search(string Timkiemsp, string sortOrder)
        {
            var sp = from s in db.SanPhams select s;

            if (!string.IsNullOrEmpty(Timkiemsp))
            {
                sp = db.SanPhams.Where(s => s.tensp.Contains(Timkiemsp));
            }
            ViewBag.SearchTerm = Timkiemsp;
            switch (sortOrder)
            {
                case "name_desc":
                    sp = sp.OrderByDescending(s => s.tensp);
                    break;
                default:
                    sp = sp.OrderBy(s => s.tensp);
                    break;
            }
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            return View(sp.ToList());
        }

        public ActionResult sanpham1()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
    }
}