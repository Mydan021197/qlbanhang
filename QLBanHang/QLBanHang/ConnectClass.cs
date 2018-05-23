using QLBanHang.Areas.QuanLy.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBanHang
{
    namespace NhanVien
    {
        public class ConnectClass
        {

            public bool Login(string tendn, string pass)
            {
                return DataProvider.Instance.ExcuteQuery("dangnhap @tendn , @pass ", new object[] { tendn, pass }).Rows.Count == 1;
            }
        }

    }
    namespace Nhaphang
    {
        public class ConnectClass
        {   
            public ConnectClass() { }
          
            public bool create(int idnpp, string tennv)
            {
                return DataProvider.Instance.ExcuteNonQuery("InsertPhieuNhap @idNPP , @tenNV", new object[] { idnpp, tennv }) > 0;
            }
            //public bool CreateSP(string tensp ,int phai ,string dvt, string hinhAnh, string mota,string idHieu ,string idDungLuong ,string NongDo,int soluongnhap, int idnpp,int idnv, int gianhap, DateTime ngaynhap)
            //{
            //    return DataProvider.Instance.ExcuteNonQuery("InsertSanPham @tensp ,@phai, @dvt, @mota, @Hieu, @DungLuong,@NongDo, @soluongnhap, @idnpp, @idnv, @gianhap, @ngaynhap, @hinhanh", new object[] {tensp, phai, dvt, mota, idHieu ,idDungLuong,NongDo,soluongnhap,idnpp ,idnv, gianhap ,ngaynhap, hinhAnh }) > 0;
            //}
            public bool CreateSP(NhapHang nhapHang)
            {
                return DataProvider.Instance.ExcuteNonQuery(
                    "InsertSanPham " +
                    "@idphieunhap , @tensp , @phai , @dvt , @mota , @idhieu , @iddungluong , " +
                    "@idnongdo , @soluongnhap , @idnv , @gianhap , @hinhanh "
                    , new object[] 
                    { nhapHang.idPN, nhapHang.tensp, nhapHang.phai, nhapHang.dvt, nhapHang.mota, nhapHang.idHieu, nhapHang.idDungLuong, nhapHang.idNongDo, nhapHang.soluong, nhapHang.idNhanvien, nhapHang.gianhap, nhapHang.HinhAnh}) > 0;
            }

            public List<NhanHieu> LoadNhanHieu()
            {

                List<NhanHieu> result = new List<NhanHieu>();
                DataTable dt = DataProvider.Instance.ExcuteQuery("pLoadNhanHieu");
                foreach (DataRow item in dt.Rows)
                {
                    NhanHieu tmp = new NhanHieu(item);
                    result.Add(tmp);
                }
                return result;

            }

            public List<GioiTinh> LoadGioiTinh()
            {

                List<GioiTinh> result = new List<GioiTinh>();
                DataTable dt = DataProvider.Instance.ExcuteQuery("pLoadGioiTinh");
                foreach (DataRow item in dt.Rows)
                {
                    GioiTinh tmp = new GioiTinh(item);
                    result.Add(tmp);
                }
                return result;
            }
            public List<NongDo> LoadNongdo()
            {

                List<NongDo> result = new List<NongDo>();
                DataTable dt = DataProvider.Instance.ExcuteQuery("pLoadNongDo");
                foreach (DataRow item in dt.Rows)
                {
                    NongDo tmp = new NongDo(item);
                    result.Add(tmp);
                }
                return result;

            }
            public List<DungLuong> LoadDungluong()
            {

                List<DungLuong> result = new List<DungLuong>();
                DataTable dt = DataProvider.Instance.ExcuteQuery("pLoadDungluong");
                foreach (DataRow item in dt.Rows)
                {
                    DungLuong tmp = new DungLuong(item);
                    result.Add(tmp);
                }
                return result;

            }
            public List<NPP> LoadNPP()
            {

                List<NPP> result = new List<NPP>();
                DataTable dt = DataProvider.Instance.ExcuteQuery("pLoadNPP");
                foreach (DataRow item in dt.Rows)
                {
                    NPP tmp = new NPP(item);
                    result.Add(tmp);
                }
                return result;

            }
            public List<Admin> LoadNhanvien()
            {

                List<Admin> result = new List<Admin>();
                DataTable dt = DataProvider.Instance.ExcuteQuery("pLoadNhanvien");
                foreach (DataRow item in dt.Rows)
                {
                    Admin tmp = new Admin(item);
                    result.Add(tmp);
                }
                return result;

            }
            public List<CTPhieuNhap> GetListCTPhieuNhap(int id)
            {
                List<CTPhieuNhap> result = new List<CTPhieuNhap>();
                DataTable data = DataProvider.Instance.ExcuteQuery("exec pLoadCTPhieu @idPhieu", new object[] { id });
                foreach (DataRow row in data.Rows)
                {
                    CTPhieuNhap temp = new CTPhieuNhap(row);
                    temp.SanPham = new SanPham(DataProvider.Instance.ExcuteQuery("Select * from dbo.SANPHAM where id = " + temp.idSp).Rows[0]);
                    result.Add(temp);
                }
                return result;
            }
            public List<CTDonMua> chitietdonmua(int id)
            {
                List<CTDonMua> result = new List<CTDonMua>();
                DataTable data = DataProvider.Instance.ExcuteQuery("exec pchitietdonmua @idphieu", new object[] { id });
                foreach (DataRow row in data.Rows)
                {
                    CTDonMua temp = new CTDonMua(row);
                    temp.SanPham = new SanPham(DataProvider.Instance.ExcuteQuery("Select * from dbo.SANPHAM sp where id = " + temp.idSp).Rows[0]);
                    //temp.SanPham.idDungLuong = new SanPham(DataProvider.Instance.ExcuteQuery("dun");
                    result.Add(temp);
                }
                return result;
            }
            //public ChiTietPhieuLoad PhieuNhap(int id)
            //{
            //    ChiTietPhieuLoad result = new ChiTietPhieuLoad();
            //  //  result.phieunhap = GetPhieuNhap(id);
            //    result.dsPhieu = GetListCTPhieuNhap(id);
            //    return result;
            //}
        }
    }
    namespace nhanHieuC
    {
        public class ConnectClass
        {
            public ConnectClass() { }
          
            public bool create(string tenhieu)
            {
                return DataProvider.Instance.ExcuteNonQuery("InsertNhanHieu @tenhieu", new object[] { tenhieu }) > 0;
            }
            public bool edit(int id, string tenhieu)
            {
                return DataProvider.Instance.ExcuteNonQuery("EditNhanHieu @id , @tenhieu", new object[] { id, tenhieu }) > 0;
            }
            public bool delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("DeleteNhanHieu @id", new object[] { id }) > 0;
            }
        }
    }
    namespace khachHang
    {
        public class ConnectClass
        {
            public bool create(KhachHang khachHang)
            {
                return DataProvider.Instance.ExcuteNonQuery("InsertKhachHang @hoten , @sdt , @diachi , @tendn , @pass", new object[] { khachHang.Hoten, khachHang.Sdt, khachHang.DiaChi, khachHang.tenDN, khachHang.pass}) > 0;
            }
            public bool edit(KhachHang khachHang)
            {
                return DataProvider.Instance.ExcuteNonQuery("EditKhachHang  @id , @hoten , @sdt , @diachi ,  @phai , @tendn , @pass", new object[] {khachHang.Id,khachHang.Hoten, khachHang.Sdt, khachHang.DiaChi, khachHang.tenDN, khachHang.pass }) > 0;
            }
         
        }
    }
    namespace nongDo
    {
        public class ConnectClass
        {
            public bool create(string nongdo)
            {
                return DataProvider.Instance.ExcuteNonQuery("InsertNongDo @NongDo", new object[] { nongdo }) > 0;
            }
            public bool edit(int id, string nongdo)
            {
                return DataProvider.Instance.ExcuteNonQuery("EditNongDo @id , @NongDo", new object[] { id, nongdo }) > 0;
            }
            public bool delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("DeleteNongDo @id", new object[] { id }) > 0;
            }
        }
    }
    namespace dungLuong
    {
        public class ConnectClass
        {
            public bool create(string dungtich)
            {
                return DataProvider.Instance.ExcuteNonQuery("InsertDungLuong @DungTich", new object[] { dungtich }) > 0;
            }
            public bool edit(int id, string dungtich)
            {
                return DataProvider.Instance.ExcuteNonQuery("EditDungLuong @id , @DungTich", new object[] { id, dungtich}) > 0;
            }
            public bool delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("DeleteDungLuong @id", new object[] { id }) > 0;
            }
        }
    }
    namespace nhaPhanPhoi
    {
        public class ConnectClass
        {
            public bool create(string npp)
            {
                return DataProvider.Instance.ExcuteNonQuery("InsertNhaPhanPhoi @tennpp", new object[] { npp }) > 0;
            }
            public bool edit(int id, string npp)
            {
                return DataProvider.Instance.ExcuteNonQuery("EditNhaPhanPhoi @id , @tennpp", new object[] { id, npp }) > 0;
            }
            public bool delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("DeleteNhaPhanPhoi @id", new object[] { id }) > 0;
            }
        }
    }
    namespace phieuNhap
    {
        public class ConnectClass
        {
        
            public bool delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("DeletePhieuNhap @id", new object[] { id }) > 0;
            }
        }
    }
    namespace chitietphieunhap
    {
        public class ConnectClass
        {
            public bool create( int idpn, int idsp, int gianhap,int soluongnhap)
            {
                return DataProvider.Instance.ExcuteNonQuery("InsertChiTietPhieuNhap @idPN , @idSP , @gianhap , @soluongnhap", new object[] { idpn,idsp,gianhap,soluongnhap}) > 0;
            }
            public bool edit(int id,int idpn, int idsp, int gianhap, int soluongnhap)
            {
                return DataProvider.Instance.ExcuteNonQuery("EditChiTietPhieuNhap @id , @idPN , @idSP , @gianhap , @soluongnhap", new object[] { id, idpn, idsp, gianhap, soluongnhap }) > 0;
            }
            public bool delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("DeleteChiTietPhieuNhap @id", new object[] { id }) > 0;
            }
        }
    }
    namespace sanpham
    {
        public class ConnectClass
        {

            public bool create(string tensp, int phai, string dvt , int GiaBan , string mota , string Hieu ,  string DungLuong, string NongDo )
            {
                return DataProvider.Instance.ExcuteNonQuery("InsertSanPham @tensp , @phai , @dvt , @GiaBan ,  @mota , @Hieu , @DungLuong , @NongDo ", new object[] { tensp, phai , dvt , GiaBan , mota , Hieu , DungLuong , NongDo}) > 0;
            }
            public bool edit(int id, string tensp, int phai, string dvt, int GiaBan, string mota, string Hieu, string DungLuong, string NongDo,string filename = null)
            {
                return DataProvider.Instance.ExcuteNonQuery("EditSanPham @idsp , @tensp , @phai , @dvt , @GiaBan ,  @mota , @Hieu , @DungLuong , @NongDo , @hinhanh ", new object[] { id, tensp , phai , dvt , GiaBan , mota , Hieu , DungLuong , NongDo ,filename }) > 0;
            }
            public bool delete(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("XoaSanPham @id", new object[] { id }) > 0;
            }
            public bool details(int id)
            {
                return DataProvider.Instance.ExcuteNonQuery("Details_SP @id", new object[] { id }) > 0;
            }
        }
    }
    namespace loadhang
    {
        public class ConnectClass
        {
            public bool LoadHang(int trangthai)
            {
                return DataProvider.Instance.ExcuteQuery("loadDatHang @TrangThai ", new object[] { trangthai }).Rows.Count == 1;
            }
        }
    }
}