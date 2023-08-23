﻿using Kuleli.Shop.Application.Model.Dtos.Customers;
using Kuleli.Shop.Domain.Entities;

namespace Kuleli.Shop.Application.Model.Dtos.Accounts
{
    public class AccountDto
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string LastUserIp { get; set; }
        public Roles Role { get; set; }
        public CustomerDto Customer { get; set; }

    }
}