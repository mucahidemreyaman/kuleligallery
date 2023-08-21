using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.ProductImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Validators.ProductImages
{
    public class DeleteProductImageValidator : AbstractValidator<DeleteProductImageVM>
    {
        public DeleteProductImageValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("SILINECEK URUN RESMINE AIT KIMLIK BILGISI BOS BIRAKILAMAZ.")
                .GreaterThan(0).WithMessage("SILINECEK URUN RESMI KIMLIK BILGISI  SIFIRDAN BUYUK OLMALDIR.");
        }
    }
}
