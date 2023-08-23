using Kuleli.Shop.Domain.Entities;

namespace Kuleli.Shop.Application.Model.Dtos.Accounts
{
    public class TokenDto
    {   
        public Roles Role { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
