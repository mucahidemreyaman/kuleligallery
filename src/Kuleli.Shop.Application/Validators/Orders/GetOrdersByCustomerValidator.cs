using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.Orders;

namespace Kuleli.Shop.Application.Validators.Orders
{
    public class GetOrdersByCustomerValidator : AbstractValidator<GetOrdersByCustomerVM>
    {
        public GetOrdersByCustomerValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("MUSTERI NUMARASI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("MUSTERI NUMARASI SIFIRDAN BUYUK OLMALIDIR.");
        }
    }
}
