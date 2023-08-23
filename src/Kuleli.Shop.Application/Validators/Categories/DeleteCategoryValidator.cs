using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Validators.Categories
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryViewModel>
    {
        public DeleteCategoryValidator()         
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("KATEGORI KIMLIK NUMARASI BOS BIRAKILAMAZ!")
                .GreaterThan(0)//SIFIRDAN BUYUK YAPMAMIZI SAGLAR...
                .WithMessage("KATEGORI KIMLIK NUMARASI SIFIRDAN BUYUK OLMALIDIR!");

        }
    }
}
