using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBanHang.Areas.QuanLy.Models
{
    public class chitietdonhangload
    {
        public DatHang dathang { get; set; }

        public List<CTDonMua> ctdonmua { get; set; }

        public SanPham sp { get; set; }

    }
}