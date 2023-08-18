using Kuleli.Shop.Application.Model.Dtos.CategoryDtos;
using Kuleli.Shop.Application.Model.RequestModels.CategoryModels;
using Kuleli.Shop.Application.Services.Absraction.AccountService;
using Kuleli.Shop.Application.Services.Absraction.CategoryService;
using Kuleli.Shop.Application.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace KuleliGallery.APİ.Controller.CategoryController
{

    //Endpoint url : [ControllerRoute]/[ActionRoute]
    //category/getall
    [ApiController]
    [Route("category")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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