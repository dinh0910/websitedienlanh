using Microsoft.AspNetCore.Mvc;

namespace websitedienlanh.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BaoCaosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
