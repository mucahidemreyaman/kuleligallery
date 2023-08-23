using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Validators.Accounts
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserVM>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("GUNCELLENECEK KULLANICI KIMLIK NUMARASI GIRILMELIDIR.");

            RuleFor(x => x.CityId)
                .NotEmpty().WithMessage("GECERLI BIR IL GIRINIZ.")
                .LessThan(82).WithMessage("GECERSIZ BIR IL NUMARASI GIRILDU");

            RuleFor(x => x.IdentityNumber)
                .NotEmpty().WithMessage("TC KIMLIK NUMARASI BOS BIRAKILAMAZ.")
                .MaximumLength(11).WithMessage("TC KIMLIK NUMARASI 11 KARAKTERDEN BUYUK OLAMAZ.")
                .MinimumLength(11).WithMessage("Tc kimlik numarası 11  KARAKTERDEN KUCUK OLAMAZ.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("AD BILGISI BOS OLAMAZ.")
                .MaximumLength(30).WithMessage("AD BILGISI 30 KARAKTERDEN BUYUK OLAMAZ.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("SOYAD BILGISI BOS OLAMAZ.")
                .MaximumLength(30).WithMessage("SOYAD BILGISI 30 KARAKTERDEN BUYUK OLAMAZ.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("TELEFON NO BILGISI BOS BIRAKILAMAZ.")
                .MaximumLength(13).WithMessage("TELEFON NO BILGISI 13 KARAKTERDEN BUYUK OLAMAZ.");

            RuleFor(x => x.Birtdate)
                .NotEmpty().WithMessage("DOGUM TARIHI BILGISI BOS BIRAKILAMAZ.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("CINSIYET BILGISI BOS BIRAKILAMAZ.")
                .IsInEnum().WithMessage("CINSIYET BILGISI GECERLI DEGIL (1 veya 2 SECILMELIDIR.)");

        }
    }
}
