using AutoMapper;
using Kuleli.Gallery.Utilies;
using Kuleli.Shop.Application.Behaviors;
using Kuleli.Shop.Application.Model.RequestModels.AccountModels;
using Kuleli.Shop.Application.Services.Absraction.AccountService;
using Kuleli.Shop.Application.Validators.Accounts;
using Kuleli.Shop.Domain.Entities;
using Kuleli.Shop.Domain.UWork;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Kuleli.Shop.Application.Services.Implementation.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitwork _uWork;
        private readonly IConfiguration _configuration;

        public AccountService(IMapper mapper, IUnitwork uWork, IConfiguration configuration)
        {
            _mapper = mapper;
            _uWork = uWork;
            _configuration = configuration;
        }

        [ValidationBehavior(typeof(CreateUserValidator))]
        public async Task<bool> CreateUser(CreateUserVM createUserVM)
        {
            //GELEN MODEL CUSTOMER TURUNE MAPLENDI
            var customerEntity = _mapper.Map<Customer>(createUserVM);

            //GELEN MODEL ACCOUNT TURUNE MAPLENDI
            var accountEntity = _mapper.Map<Account>(createUserVM);

            accountEntity.Password = CipherUtil.EncryptString(_configuration["AppSettings:SecretKey"], accountEntity.Password);


            _uWork.GetRepository<Customer>().Add(customerEntity);
            accountEntity.Customer = customerEntity;
            _uWork.GetRepository<Account>().Add(accountEntity);

            await _uWork.CommitAsync();

            var result = await _uWork.CommitAsync();

            return result;
        }
    }
}
