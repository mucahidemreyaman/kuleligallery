using AutoMapper;
using Kuleli.Shop.Application.Behaviors;
using Kuleli.Shop.Application.Model.RequestModels.AccountModels;
using Kuleli.Shop.Application.Services.Absraction.AccountService;
using Kuleli.Shop.Application.Validators.Accounts;
using Kuleli.Shop.Domain.Entities;
using Kuleli.Shop.Domain.UWork;
using System.ComponentModel.DataAnnotations;

namespace Kuleli.Shop.Application.Services.Implementation.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitwork _uWork;

        public AccountService(IMapper mapper, IUnitwork uWork)
        {
            _mapper = mapper;
            _uWork = uWork;
        }

        [ValidationBehavior(typeof(CreateUserValidator))]
        public async Task<bool> CreateUser(CreateUserVM createUserVM)
        {
            //GELEN MODEL CUSTOMER TURUNE MAPLENDI
            var customerEntity = _mapper.Map<Customer>(createUserVM);

            //GELEN MODEL ACCOUNT TURUNE MAPLENDI
            var accountEntity = _mapper.Map<Account>(createUserVM);

            await _uWork.GetRepository<Customer>().Add(customerEntity);
            await _uWork.GetRepository<Account>().Add(accountEntity);
            
            await _uWork.CommitAsync();

            var result = await _uWork.CommitAsync();

            return result;
        }
    }
}
