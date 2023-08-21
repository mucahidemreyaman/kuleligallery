using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.Order;

namespace Kuleli.Shop.Application.Validators.Orders
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderVM>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("MUSTERI NUMARASI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("MUSTERI NUMARASI SIFIRDAN BUYUK OLMALIDIR.");

            RuleFor(x => x.AddressId)
                .NotEmpty().WithMessage("ADRES KIMLIK NUMARASI BOS OLAMAZ")
                .GreaterThan(0).WithMessage("ADRES KIMLIK NUMARASI SIFIRDAN BUYUK BIR SAYI OLMALIDIR");
        }
    }
}
