using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Validators.Products
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductVM>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("SILINECEK URUNUN KIMLIK BILGISI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("SILINECEK URUNUN KIMLIK BILGISI SIFIRDAN BUYUK OLMALIDIR.");
        }
    }
}
