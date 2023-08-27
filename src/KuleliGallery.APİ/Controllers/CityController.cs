using Kuleli.Shop.Application.Model.Dtos.Cities;
using Kuleli.Shop.Application.Model.RequestModels.Cities;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Application.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KuleliGallery.Api.Controller
{
    //Endpoint url : [ControllerRoute]/[ActionRoute]
    //category/getAll

    [ApiController]
    [Route("city")]
    [Authorize(Roles = "Admin")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("get")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<List<CityDto>>>> GetAllCities()
        {
            var categories = await _cityService.GetAllCities();
            return Ok(categories);
        }

        [HttpGet("get/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<CityDto>>> GetCityById(int id)
        {
            var category = await _cityService.GetCityById(id);
            return Ok(category);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateCity(CreateCityVM createCityVM)
        {
            var categoryId = await _cityService.CreateCity(createCityVM);
            return Ok(categoryId);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateCity(int id, UpdateCityVM updateCityVM)
        {
            if (id != updateCityVM.Id)
            {
                return BadRequest();
            }
            var categoryId = await _cityService.UpdateCity(updateCityVM);
            return Ok(categoryId);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteCity(int id)
        {
            var categoryId = await _cityService.DeleteCity(id);
            return Ok(categoryId);
        }

    }
}
