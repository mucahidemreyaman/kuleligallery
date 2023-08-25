using FluentValidation;
using KuleliGallery.Shop.UI.Models.RequestModels.ProductImages;

namespace KuleliGallery.Shop.UI.Validators.ProductImages
{
    public class CreateProductImageValidator : AbstractValidator<CreateProductImageVM>
    {
        public CreateProductImageValidator()
        {
            var allowedContentTypes = new string[] { "image/jpg", "image/jpeg", "image/png", "image/gif", "image/tiff" };

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Ürün kimlik bilgisi boş olamaz.");

            RuleFor(x => x.ImageFile)
                .NotNull().WithMessage("Resim dosyası seçilmelidir.")
                .Must(x => x.Length < 1 * 1024 * 1024).WithMessage("Dosya boyutu 1 MB'dan büyük olamaz.")
                .Must(x => allowedContentTypes.Contains(x.ContentType)).WithMessage("Sadece resim dosyası seçilebilir.");
        }
    }
}
