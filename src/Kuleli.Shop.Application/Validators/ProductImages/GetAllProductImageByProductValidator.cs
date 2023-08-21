using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.ProductImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Validators.ProductImages
{
    public class GetAllProductImageByProductValidator : AbstractValidator<GetAllProductImageByProductVM>
    {
        public GetAllProductImageByProductValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull().WithMessage("URUNE AIT KIMLIK BILGISI BOS BIRAKILAMAZ.")
                .GreaterThan(0).WithMessage("URUNE AIT KIMLIK BILGISI SIFIRDAN BUYUK OLMALIDIR.");
        }
    }
}
