using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductVM>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("URUN KIMLIK BILGISI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("URUNUN KIMLIK BILGISI SIFIRDAN BUYUK OLMALIDIR.");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("URUNE AIT KATEGORI BILGISI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("KATEGORI BILGISI SIFIRDAN BUYUK OLMALIDIR.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("URUN ADI BOS OLAMAZ.")
                .MaximumLength(255).WithMessage("URUN ADI EN FAZLA 255 KARAKTER OLABILIR.");

            RuleFor(x => x.Detail)
                .NotNull().WithMessage("URUN DETAY BILGISI BOS OLAMAZ.");

            RuleFor(x => x.UnitInStock)
                .NotNull().WithMessage("URUN STOK ADEDI BOS OLAMAZ.");

            RuleFor(x => x.UnitPrice)
                .NotNull().WithMessage("URUN FIYATI BOS OLAMAZ.");
        }
    }
}
