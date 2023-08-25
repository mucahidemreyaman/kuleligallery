using KuleliGallery.Shop.UI.Models.Dtos;
using KuleliGallery.Shop.UI.Models.Dtos.Products;
using KuleliGallery.Shop.UI.Models.RequestModels.Products;
using KuleliGallery.Shop.UI.Models.Wrapper;
using KuleliGallery.Shop.UI.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace KuleliGallery.Shop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy ="Admin")]
    public class ProductController : Controller
    {
        private readonly IRestService _restService;

        public ProductController(IRestService restService)
        {
            _restService = restService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Header = "ÜRÜN İŞLEMLERİ";
            ViewBag.Title = "YENİ ÜRÜN EKLE";

            var response = await _restService.GetAsync<Result<List<CategoryDto>>>("category/get");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                TempData["error"] = "DEVAM ETMEK İÇİN LÜTFEN SİSTEME GİRİŞ YAPINIZ.";
                return RedirectToAction("SignIn", "Login", new { Area = "Admin" });
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                TempData["error"] = "BU İŞLEM İÇİN YETKİNİZ BULUNMAMAKTADIR.";
                return RedirectToAction("SignIn", "Login", new { Area = "Admin" });
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "SUNUCU TARAFLI BIR HATA OLUSTU. LUTFEN SISTEM YONETICINIZE BASVURUNUZ.");
                return View();
            }
            else
            {
                //Kategori listesini açılır kutuya uygun formata dönüşüm
                ViewBag.Categories = response.Data.Data.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                });
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductModel)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createProductModel);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateProductVM, Result<int>>(createProductModel, "product/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} NUMARALI KAYIT BASARIYLA EKLENDİ.";
                return RedirectToAction("List", "Product", new { Area = "Admin" });
            }

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Ürün İşlemleri";
            ViewBag.Title = "Ürün Düzenle";

            //Apiye istek at
            //category/get
            var response = await _restService.GetAsync<Result<List<ProductWithCategoryDto>>>("product/getWithCategory");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "SUNUCU TARAFLI BIR HATA OLUSTU. LUTFEN SISTEM YONETICINIZE BASVURUNUZ.");
                return View();
            }
            else
            {
                return View(response.Data.Data);
            }
        }
    }
}
