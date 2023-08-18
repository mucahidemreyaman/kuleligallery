using Kuleli.Shop.Application.Model.RequestModels.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Services.Absraction.AccountService
{
    public interface IAccountService
    {
        Task<bool> CreateUser(CreateUserVM createUserVM);

    }
}
