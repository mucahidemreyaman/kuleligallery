using Kuleli.Shop.Application.Model.Dtos;
using Kuleli.Shop.Application.Services.Absraction;
using Microsoft.AspNetCore.Mvc;

namespace KuleliGallery.APİ.Controllers
{

    //Endpoint url : [ControllerRoute]/[ActionRoute]
    //category/getall
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }   
             

        [HttpGet("getAll")]
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await _categoryServices.GetAllCategories();
           return categories;
        }
    }
}