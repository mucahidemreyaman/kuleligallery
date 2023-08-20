using Kuleli.Shop.Application.Model.Dtos.AccountDtos;
using Kuleli.Shop.Application.Model.RequestModels.AccountModels;
using Kuleli.Shop.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Services.Absraction.AccountService
{
    public interface IAccountService
    {
        Task<Result<bool>> Register(RegisterVM createUserVM);

        Task<Result<TokenDto>> Login(LoginVM loginVM);

        Task<Result<bool>> UpdateUser(UpdateUserVM updateUserVM);

    }
}
