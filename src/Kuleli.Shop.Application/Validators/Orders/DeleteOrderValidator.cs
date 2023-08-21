using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.Orders;

namespace Kuleli.Shop.Application.Validators.Orders
{
    public class DeleteOrderValidator : AbstractValidator<DeleteOrderVM>
    {
        public DeleteOrderValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("SIPARIS NUMARASI BOS BIRAKILAMAZ.")
                .GreaterThan(0).WithMessage("SIPARIS NUMARASI SIFIRDAN BUYUK OLMALIDIR.");
        }
    }
}
