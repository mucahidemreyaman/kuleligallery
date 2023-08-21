using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.OrderDetails;

namespace Kuleli.Shop.Application.Validators.OrderDetails
{
    public class GetOrderDetailsByOrderIdValidator : AbstractValidator<GetOrderDetailsByOrderIdVM>
    {
        public GetOrderDetailsByOrderIdValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("SIPARIS NUMARASI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("SIPARIS NUMARASI SIFIRDAN BUYUK OLMALIDIR.");
        }
    }
}
