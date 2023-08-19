using Kuleli.Shop.Application.Model.Dtos.CategoryDtos;
using Kuleli.Shop.Application.Model.RequestModels.AccountModels;
using Kuleli.Shop.Application.Model.RequestModels.CategoryModels;
using Kuleli.Shop.Application.Services.Absraction.AccountService;
using Kuleli.Shop.Application.Services.Absraction.CategoryService;
using Kuleli.Shop.Application.Validators.Accounts;
using Kuleli.Shop.Application.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace KuleliGallery.APİ.Controller.CategoryController
{

    //Endpoint url : [ControllerRoute]/[ActionRoute]
    //category/getall
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }     

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateUser(CreateUserVM createUserVM )
        {
            var categoryId = await _accountService.CreateUser(createUserVM);
            return Ok(categoryId);
        }

       
    }
}