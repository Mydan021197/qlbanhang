using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QLBanHang.Models
{
    public class Test
    {
        
        List<SanPham> list;
        public Test(int idhieu = 0)
        {
            if (idhieu != 0)
            {
                DataTable data = DataProvider.Instance.ExcuteQuery("pLoadHieu @idhieu", new object[] { idhieu });
                list = new List<SanPham>();
                foreach (DataRow row in data.Rows)
                {
                    SanPham sp = new SanPham(row);
                    list.Add(sp);
                }
            }
            else
            {
                DataTable data = DataProvider.Instance.ExcuteQuery("select * from dbo.SANPHAM");
                list = new List<SanPham>();
                foreach (DataRow row in data.Rows)
                {
                    SanPham sp = new SanPham(row);
                    list.Add(sp);
                }
            }
        }
    }
}