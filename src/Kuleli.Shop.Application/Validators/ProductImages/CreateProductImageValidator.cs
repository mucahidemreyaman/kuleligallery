using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.ProductImages;

namespace Kuleli.Shop.Application.Validators.ProductImages
{
    public class CreateProductImageValidator : AbstractValidator<CreateProductImageVM>
    {
        public CreateProductImageValidator()
        {
            var allowedContentTypes = new string[] { "image/jpg", "image/jpeg", "image/png", "image/gif", "image/tiff" };

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("URUN KIMLIK BILGISI BOS OLAMAZ.");

            RuleFor(x => x.UploadedImage)
                .NotNull().WithMessage("RESIM DOSYASI SECINIZ.")
                .Must(x => x.Length < 1 * 1024 * 1024).WithMessage("DOSYA BOYUTU 1 MB'DAN FAZLA OLAMAZ.")
                .Must(x => allowedContentTypes.Contains(x.ContentType)).WithMessage("DOSYA UZANTISI DESTEKLENMIYOR.");
        }
    }
}

