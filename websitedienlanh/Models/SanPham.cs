﻿using System.ComponentModel.DataAnnotations;

namespace websitedienlanh.Models
{
    public class SanPham
    {
        public int SanPhamID { get; set; }

        public int DanhMucID { get; set; }
        public DanhMuc? DanhMuc { get; set; }

        public int ThuongHieuID { get; set; }
        public ThuongHieu? ThuongHieu { get; set; }

        public string? Ten { get; set; }

        public string? HinhAnh { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int DonGia { get; set; }

        public int SoLuong { get; set; }
    }
}
