using KuleliGallery.Shop.UI.Models.RequestModels.ProductImages;
using FluentValidation;

namespace KuleliGallery.Shop.UI.Validators.ProductImages
{
    public class GetAllProductImageByProductValidator : AbstractValidator<GetAllProductImageByProductVM>
    {
        public GetAllProductImageByProductValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull().WithMessage("Ürüne ait kimlik bilgisi boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürüne ait kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
