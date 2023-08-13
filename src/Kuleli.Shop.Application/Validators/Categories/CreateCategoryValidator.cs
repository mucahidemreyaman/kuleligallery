using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels;

namespace Kuleli.Shop.Application.Validators.Categories
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryViewModel>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x=>x.CategoryName)
                .NotEmpty()
                .WithMessage("KATEGORI ADI BOS BIRAKILAMAZ")
                .MaximumLength(100)
                .WithMessage("KATEGORI ADI 100 KARAKTERDEN FAZLA OLAMAZ");
        }
    }
}
