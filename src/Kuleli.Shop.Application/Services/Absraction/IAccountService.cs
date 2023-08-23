using Kuleli.Shop.Application.Model.Dtos.Accounts;
using Kuleli.Shop.Application.Model.RequestModels.Accounts;
using Kuleli.Shop.Application.Wrapper;

namespace Kuleli.Shop.Application.Services.Absraction
{
    public interface IAccountService
    {
        Task<Result<bool>> Register(RegisterVM createUserVM);

        Task<Result<TokenDto>> Login(LoginVM loginVM);

        Task<Result<bool>> UpdateUser(UpdateUserVM updateUserVM);

    }
}
