using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.Orders;

namespace Kuleli.Shop.Application.Validators.Orders
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderVM>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("SIPARIS NUMARASI BOS BIRAKILAMAZ.")
                .GreaterThan(0).WithMessage("SIPARIS NUMARASI SIFIRDAN BUYUK OLMALIDIR.");

            RuleFor(x => x.AddressId)
                .NotEmpty().WithMessage("ADRES KIMLIK NUMARASI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("ADRES KIMLIK NUMARASI SIFIRDAN BUYUK BIR SAYI OLMALIDIR.");

            RuleFor(x => x.StatusId)
                .NotEmpty().WithMessage("SIPARIS DURUMU BOS OLAMAZ.")
                .IsInEnum().WithMessage("SIPARIS DURUMU GECERLI DEGILDIR.");
        }
    }
}
