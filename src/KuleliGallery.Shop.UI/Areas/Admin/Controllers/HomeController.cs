using Microsoft.AspNetCore.Mvc;

namespace KuleliGallery.Shop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Header = "KULELI GALLERY";
            ViewBag.Title = "YONETICI PANELI";
            return View();
        }
    }
}
