using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using websitedienlanh.Data;
using websitedienlanh.Libs;
using websitedienlanh.Models;

namespace websitedienlanh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly websitedienlanhContext _context;

		public const string SessionTKAdmin = "_TaiKhoanID";
		public const string SessionHoten = "_HoTen";
		public const string SessionTenDN = "_TenTaiKhoan";
		public const string SessionEmail = "_Email";
		public const string SessionSDT = "_SDT";
		public const string SessionDiaChi = "_DiaChi";
		public const string SessionQuyen = "_QuyenID";

		public HomeController(ILogger<HomeController> logger, websitedienlanhContext context)
        {
            _logger = logger;
			_context = context;
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(TaiKhoanLogin TaiKhoan)
		{
			if (ModelState.IsValid)
			{
				string mahoamatkhau = SHA1.ComputeHash(TaiKhoan.MatKhau);
				var taiKhoan = await _context.TaiKhoan.FirstOrDefaultAsync(r => r.TenTaiKhoan == TaiKhoan.TenTaiKhoan
																			&& r.MatKhau == mahoamatkhau
																			&& (r.QuyenHanID == 1 || r.QuyenHanID == 2));

				if (taiKhoan == null)
				{
					//_toastNotification.AddErrorToastMessage("Đăng nhập không thành công!");
				}
				else
				{
					// Đăng ký SESSION
					HttpContext.Session.SetInt32(SessionTKAdmin, (int)taiKhoan.TaiKhoanID);
					HttpContext.Session.SetString(SessionTenDN, taiKhoan.TenTaiKhoan);
					//HttpContext.Session.SetString(SessionHoten, taiKhoan.HoTen);
					//HttpContext.Session.SetString(SessionEmail, taiKhoan.Email);
					//HttpContext.Session.SetString(SessionSDT, taiKhoan.SoDienThoai);
					//HttpContext.Session.SetString(SessionDiaChi, taiKhoan.DiaChi);
					//_toastNotification.AddSuccessToastMessage("Đăng nhập thành công!");
					return RedirectToAction("Index", "Home");
				}
			}
			return RedirectToAction("Login", "Home");
		}

		[Route("/admin")]
		public IActionResult Login()
		{
			if (HttpContext.Session.GetInt32("_TaiKhoanID") == null)
			{
				return View();
			}
			return RedirectToAction("Index", "Home");
		}

		[Route("/admin/home")]
		public IActionResult Index()
        {
            return View();
        }

		public ActionResult Logout()
		{
			HttpContext.Session.Remove("_TaiKhoanID");
			//HttpContext.Session.Remove("_Hoten");
			HttpContext.Session.Remove("_TenTaiKhoan");
			//HttpContext.Session.Remove("_Quyen");
			//HttpContext.Session.Remove("_HinhAnh");
			//HttpContext.Session.Remove("_Email");

			return RedirectToAction("Index", "Home");
		}
	}
}