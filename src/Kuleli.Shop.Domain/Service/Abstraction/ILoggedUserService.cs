using Kuleli.Shop.Domain.Entities;
namespace Kuleli.Shop.Domain.Service.Abstraction
{
    public interface ILoggedUserService
    {
        int? UserId { get; }
        Roles? Role { get; }
        string Username { get; }
        string Email { get; }
    }
}
