using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels;

namespace Kuleli.Shop.Application.Validators.Categories
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryVievModel>
    {
        public UpdateCategoryValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("KATEGORI KIMLIK NUMARASI BOS BIRAKILAMAZ!")
                .GreaterThan(0)//SIFIRDAN BUYUK YAPMAMIZI SAGLAR...
                .WithMessage("KATEGORI KIMLIK NUMARASI SIFIRDAN BUYUK OLMALIDIR!");

            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .WithMessage("KATEGORI ADI BOS BIRAKILAMAZ")
                .MaximumLength(100)
                .WithMessage("KATEGORI ADI 100 KARAKTERDEN FAZLA OLAMAZ");
        }
    }
}                                                                        
