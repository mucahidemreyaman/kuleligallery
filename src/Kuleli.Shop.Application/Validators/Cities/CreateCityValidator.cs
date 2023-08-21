using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.CittModels;

namespace Kuleli.Shop.Application.Validators.Cities
{
    public class CreateCityValidator : AbstractValidator<CreateCityVM>
    {
        public CreateCityValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("SEHIR ADI BOS OLAMAZ.")
                .MaximumLength(20).WithMessage("SEHIR ADI 20 KARAKTERDEN FAZLA OLAMAZ.");

        }
    }
}
