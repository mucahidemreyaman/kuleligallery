using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.OrderDetails;

namespace Kuleli.Shop.Application.Validators.OrderDetails
{
    public class CreateOrderDetailValidator : AbstractValidator<CreateOrderDetailVM>
    {
        public CreateOrderDetailValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("SIPARIS NUMARASI BOS BIRAKILAMAZ.")
                .GreaterThan(0).WithMessage("SIPARIS NUMARASI SIFIRDAN BUYUK OLMALIDIR.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("URUN NUMARASI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("URUN NUMARASI SIFIRDAN BUYUK OLAMAZ.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("URUN ADET BILGISI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("URUN ADET BILGISI SIFIRDAN BUYUK OLAMAZ.");
        }
    }
}
