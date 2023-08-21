using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Validators.Products
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdVM>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("URUNUN KIMLIK BILGISI BOS BIRAKILAMAZ")
                .GreaterThan(0).WithMessage("URUNUN KIMLIK BILGISI SIFIRDAN BUYUK OLMALIDIR.");
        }
    }
}
