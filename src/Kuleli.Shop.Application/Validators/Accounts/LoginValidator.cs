using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.AccountModels;

namespace Kuleli.Shop.Application.Validators.Accounts
{
    public class LoginValidator : AbstractValidator<LoginVM>
    {    
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("KULLANICI ADI BOS OLAMAZ.")
                .MaximumLength(10).WithMessage("KULLANICI ADI EN FAZLA 10 KARAKTER OLABILIR.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("PAROLA BOS OLAMAZ.")
                .MaximumLength(11).WithMessage("PAROLA EN FAZLA 11 KARAKTER OLABILIR.");
        }
    }
}
