using KuleliGallery.Shop.UI.Models.RequestModels.OrderDetails;
using FluentValidation;

namespace KuleliGallery.Shop.UI.Validators.OrderDetails
{
    public class GetOrderDetailsByOrderIdValidator : AbstractValidator<GetOrderDetailsByOrderIdVM>
    {
        public GetOrderDetailsByOrderIdValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("Sipariş numarası boş olamaz.")
                .GreaterThan(0).WithMessage("Sipariş numarası sıfırdan büyük olmalıdır.");
        }
    }
}
