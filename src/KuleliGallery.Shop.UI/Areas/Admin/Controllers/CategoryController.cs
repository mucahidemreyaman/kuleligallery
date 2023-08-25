using KuleliGallery.Shop.UI.Models.Dtos;
using KuleliGallery.Shop.UI.Models.RequestModels;
using KuleliGallery.Shop.UI.Models.Wrapper;
using KuleliGallery.Shop.UI.Services.Abstraction;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KuleliGallery.Shop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class CategoryController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public CategoryController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            ViewBag.Header = "KATEGORI İŞLEMLERİ";
            ViewBag.Title = "YENİ KATEGORİ OLUŞTUR";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM categoryModel)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(categoryModel);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateCategoryVM, Result<int>>(categoryModel, "category/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // SORUN YOK
            {
                TempData["success"] = $"{response.Data.Data} NUMARALI KAYIT BAŞARIYLA EKLENDİ.";
                return RedirectToAction("List", "Category", new { Area = "Admin" });
            }
        }

        public async Task<IActionResult> List()
        {
            ViewBag.Header = "KATEGORI İŞLEMLERİ";
            ViewBag.Title = "KATEGORİ DÜZENLE";

            //Apiye istek at
            //category/get
            var response = await _restService.GetAsync<Result<List<CategoryDto>>>("category/get");

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

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Header = "Kategori İşlemleri";
            ViewBag.Title = "Kategori Güncelle";

            //ilgili kategoriyi bul ve View'e git
            var response = await _restService.GetAsync<Result<CategoryDto>>($"category/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var model = _mapper.Map<UpdateCategoryVM>(response.Data.Data);
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryVM updateCategoryModel)
        {
            var response = await _restService.PutAsync<UpdateCategoryVM, Result<int>>(updateCategoryModel, $"category/update/{updateCategoryModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} NUMARALI KAYIT BAŞARILIYLA GÜNCELLENDİ.";
                return RedirectToAction("List", "Category", new { Area = "Admin" });
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            //api endpointi çağır
            //category/delete/id

            var response = await _restService.DeleteAsync<Result<int>>($"category/delete/{id}");

            return Json(response.Data);

        }
    }
}
