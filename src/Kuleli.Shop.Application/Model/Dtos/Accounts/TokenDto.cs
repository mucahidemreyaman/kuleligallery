using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Model.Dtos.AccountDtos
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
