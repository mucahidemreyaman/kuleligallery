using Kuleli.Shop.Domain.Entities;
namespace Kuleli.Shop.Application.Model.RequestModels.Accounts
{
    public class RegisterVM
    {
        public int CityId { get; set; }
        public string IdentityNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }   

        public string Email { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string PasswordAgain { get; set; }

    }
}
