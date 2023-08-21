using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.OrderDetails;

namespace Kuleli.Shop.Application.Validators.OrderDetails
{
    public class DeleteOrderDetailValidator : AbstractValidator<DeleteOrderDetailVM>
    {
        public DeleteOrderDetailValidator()
        {
            RuleFor(x => x.OrderDetailId)
                .NotEmpty().WithMessage("SIPARIS DETAY BILGISI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("SIPARIS DETAY NUMARASI SIFIRDAN BUYUK OLMALIDIR.");
        }
    }
}
