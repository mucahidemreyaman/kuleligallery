using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Validators.Cities
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityVM>
    {
        public UpdateCityValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("SEHIR ID NUMARASI BOS OLAMAZ.")
                .GreaterThan(0).WithMessage("SEHIR ID NUMARASI SIFIRDAN BUYUK OLAMAZ.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("SEHIR ADI BOS OLAMAZ.")
                .MaximumLength(20).WithMessage("SEHIR ADI 20 KARAKTERDEN FAZLA OLAMAZ.");

        }
    }
}
