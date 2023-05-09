using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using websitedienlanh.Data;
using websitedienlanh.Models;

namespace websitedienlanh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly websitedienlanhContext _context;

        public HomeController(ILogger<HomeController> logger, websitedienlanhContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sp = _context.SanPham.Include(s => s.DanhMuc).Include(s => s.ThuongHieu);
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.banner = _context.Banner;
            ViewBag.thuonghieu = _context.ThuongHieu;
            return View(await sp.ToListAsync());
        }

        public IActionResult Category(int? id)
        {
            var sp = _context.SanPham.Include(s => s.DanhMuc).Include(s => s.ThuongHieu).Where(s => s.DanhMucID == id);
            ViewBag.dm = _context.DanhMuc.FirstOrDefault(s => s.DanhMucID == id);
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.thuonghieu = _context.ThuongHieu;

            return View(sp);
        }

        public IActionResult TradeMark(int? id)
        {
            var sp = _context.SanPham.Include(s => s.DanhMuc).Include(s => s.ThuongHieu).Where(s => s.ThuongHieuID == id);
            ViewBag.dm = _context.ThuongHieu.FirstOrDefault(s => s.ThuongHieuID == id);
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.thuonghieu = _context.ThuongHieu;

            return View(sp);
        }

        public IActionResult Search(string? search)
        {
            var sp = _context.SanPham.Where(s => s.Ten.Contains(search));
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.thuonghieu = _context.ThuongHieu;
            return View(sp);
        }

        public const string CARTKEY = "shopcart";

        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        void SaveCartSession(List<CartItem> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString(CARTKEY, jsoncart);
        }

        // Xóa session giỏ hàng
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            ViewBag.danhmuc = _context.DanhMuc;
            var product = await _context.SanPham
                .FirstOrDefaultAsync(m => m.SanPhamID == id);
            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == id);
            if (item != null)
            {
                item.SoLuong++;
            }
            else
            {
                cart.Add(new CartItem() { SanPham = product, SoLuong = 1 });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public async Task<IActionResult> UpdateItem(int id, int quantity)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == id);
            if (quantity == 0)
            {
                cart.Remove(item);
            }
            item.SoLuong = quantity;
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public IActionResult ViewCart()
        {
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.thuonghieu = _context.ThuongHieu;
            return View(GetCartItems());
        }
        public IActionResult CheckOut()
        {
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.thuonghieu = _context.ThuongHieu;
            return View(GetCartItems());
        }

        public async Task<IActionResult> CreateBill(string Ten, string SoDienThoai, string DiaChi, string Email)
        {
            // lưu hóa đơn
            var bill = new DonDatHang();
            bill.NgayLap = DateTime.Now;
            bill.HoTen = Ten;
            bill.Sdt = SoDienThoai;
            bill.DiaChi = DiaChi;

            _context.Add(bill);
            await _context.SaveChangesAsync();

            var cart = GetCartItems();
            int amount = 0;
            int soLuong = 0;

            //chi tiết hóa đơn
            foreach (var i in cart)
            {
                var b = new ChiTietDatHang();
                b.DonDatHangID = bill.DonDatHangID;
                b.SanPhamID = i.SanPham.SanPhamID;
                b.DonGia = i.SanPham.DonGia;
                b.SoLuong = i.SoLuong;
                amount = i.SanPham.DonGia * i.SoLuong;
                b.ThanhTien = amount;

                var sp = _context.SanPham.FirstOrDefault(s => s.SanPhamID == b.SanPhamID);
                sp.SoLuong -= i.SoLuong;
                bill.TongTien += amount;
                _context.Add(b);
            }
            await _context.SaveChangesAsync();
            ClearCart();
            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.thuonghieu = _context.ThuongHieu;
            return View();
        }

        public IActionResult Details(int? id)
        {
            var sp = _context.SanPham.Include(s => s.DanhMuc).Include(s => s.ThuongHieu).FirstOrDefault(s => s.SanPhamID == id);
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.thongso = _context.ThongSo;
            ViewBag.mota = _context.MoTa;
            ViewBag.hinhanh = _context.HinhAnh;
            ViewBag.thuonghieu = _context.ThuongHieu;

            ViewBag.danhgia = _context.DanhGia;
            var listdg = _context.DanhGia.Where(d => d.SanPhamID == id);
            int average = 0;
            var total = 0;
            var count = listdg.Count();
            foreach (var item in listdg)
            {
                if (item.SanPhamID == id)
                {
                    total += item.MucDo;
                }
            }
            if(count >= 1)
            {
                average = total / count;
            }

            ViewData["average"] = average;
            ViewData["count"] = count;
            return View(sp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int? id, [Bind("DanhGiaID,SanPhamID,HoTen,Sdt,MucDo")] DanhGia danhGia)
        {
            _context.Add(danhGia);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Home", routeValues: new { id });
        }

        public async Task<IActionResult> Contact()
        {
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.thuonghieu = _context.ThuongHieu;
            return View();
        }
    }
}