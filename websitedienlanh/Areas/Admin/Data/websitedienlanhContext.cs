using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using websitedienlanh.Models;

namespace websitedienlanh.Data
{
    public class websitedienlanhContext : DbContext
    {
        public websitedienlanhContext (DbContextOptions<websitedienlanhContext> options)
            : base(options)
        {
        }

        public DbSet<websitedienlanh.Models.QuyenHan> QuyenHan { get; set; } = default!;

        public DbSet<websitedienlanh.Models.TaiKhoan>? TaiKhoan { get; set; }

        public DbSet<websitedienlanh.Models.LoaiDanhMuc>? LoaiDanhMuc { get; set; }

        public DbSet<websitedienlanh.Models.DanhMuc>? DanhMuc { get; set; }

        public DbSet<websitedienlanh.Models.Banner>? Banner { get; set; }

        public DbSet<websitedienlanh.Models.HinhAnh>? HinhAnh { get; set; }

        public DbSet<websitedienlanh.Models.DonDatHang>? DonDatHang { get; set; }

        public DbSet<websitedienlanh.Models.ChiTietDatHang>? ChiTietDatHang { get; set; }

        public DbSet<websitedienlanh.Models.MoTa>? MoTa { get; set; }

        public DbSet<websitedienlanh.Models.SanPham>? SanPham { get; set; }

        public DbSet<websitedienlanh.Models.ThongSo>? ThongSo { get; set; }

        public DbSet<websitedienlanh.Models.ThuongHieu>? ThuongHieu { get; set; }

        public DbSet<websitedienlanh.Models.NhaCungCap>? NhaCungCap { get; set; }

        public DbSet<websitedienlanh.Models.DonViTinh>? DonViTinh { get; set; }

        public DbSet<websitedienlanh.Models.NhapHang>? NhapHang { get; set; }

        public DbSet<websitedienlanh.Models.ChiTietNhapHang>? ChiTietNhapHang { get; set; }
        
        public DbSet<websitedienlanh.Models.DanhGia>? DanhGia { get; set; }
    }
}
