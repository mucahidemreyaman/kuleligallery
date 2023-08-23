using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels;

namespace Kuleli.Shop.Application.Validators.Categories
{
    public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdViewModel>
    {public GetCategoryByIdValidator()        
                       
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("KATEGORI KIMLIK NUMARASI BOS BIRAKILAMAZ!")
                .GreaterThan(0)//SIFIRDAN BUYUK YAPMAMIZI SAGLAR...
                .WithMessage("KATEGORI KIMLIK NUMARASI SIFIRDAN BUYUK OLMALIDIR!");
        }

    }
}
