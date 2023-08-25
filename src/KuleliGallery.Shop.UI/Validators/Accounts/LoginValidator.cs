using KuleliGallery.Shop.UI.Models.RequestModels.Accounts;
using FluentValidation;

namespace KuleliGallery.Shop.UI.Validators.Accounts
{
    public class LoginValidator : AbstractValidator<LoginVM>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username)  
                .NotNull().WithMessage("KULLANICI ADI BOŞ OLAMAZ.")
                .MaximumLength(10).WithMessage("KULLANICI ADI EN FAZLA 10 KARAKTER OLABİLİR.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("PAROLA BOŞ OLAMAZ.")
                .MaximumLength(10).WithMessage("PAROLA EN FAZLA 10 KARAKTER OLABİLİR.");
        }
    }
}
