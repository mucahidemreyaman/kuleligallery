using Kuleli.Shop.Application.Model.Dtos.CategoryDtos;
using Kuleli.Shop.Application.Model.RequestModels.CategoryModels;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Application.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace KuleliGallery.APİ.Controller
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


        [HttpGet("get")]
        public async Task<ActionResult<Result<List<CategoryDto>>>> GetAllCategories()
        {
            var categories = await _categoryServices.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<List<CategoryDto>>>> GetAllCategories(int id)
        {
            var categories = await _categoryServices.GetCategoryById(new GetCategoryByIdViewModel { Id = id });
            return Ok(categories);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            var categoryId = await _categoryServices.CreateCategory(createCategoryViewModel);
            return Ok(categoryId);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateCategory(int id, UpdateCategoryVievModel updateCategoryVievModel)
        {

            //status kodu değştirir

            if (id != updateCategoryVievModel.Id)
            {
                return BadRequest();
            }

            var categoryId = await _categoryServices.UpdateCategory(updateCategoryVievModel);
            return Ok(categoryId);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteCategory(int id)
        {
            var categoryId = await _categoryServices.DeleteCategory(new DeleteCategoryViewModel { Id = id });
            return Ok(categoryId);
        }
    }
}