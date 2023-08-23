using FluentValidation;
using Kuleli.Shop.Application.Model.RequestModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Validators.Accounts
{
    public class RegisterValidator : AbstractValidator<RegisterVM>
    {
        public RegisterValidator()
        {
            RuleFor(x=> x.CityId).NotEmpty().WithMessage("GECERLI BIR IL BILGISI GIRINIZ.")
                .LessThan(82).WithMessage("GECERSIZ BIR IL NUMARASI");

            RuleFor(x => x.IdentityNumber)
                .NotEmpty().WithMessage("TC KIMLIK NUMARASI BOS BIRAKILAMAZ")
                .MaximumLength(11).WithMessage("LUTFEN 11 HANELI TC KIMLIK NUMARANIZI GIRINIZ.")
                .MinimumLength(11).WithMessage("LUTFEN 11 HANELI TC KIMLIK NUMARANIZI GIRINIZ.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("LUTFEN ADINIZI GIRINIZ BU ALAN BOS BIRAKILAMAZ")
                .MaximumLength(30).WithMessage("AD BILGISI 30 KARAKTERDEN FAZLA OLAMAZ");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("LUTFEN SOYADINIZI GIRINIZ BU ALAN BOS BIRAKILAMAZ.")
                .MaximumLength(30).WithMessage("SOYAD BILGISI 30 KARAKTERDEN FAZLA OLAMAZ.");

            RuleFor(x => x.Phone)
              .NotEmpty().WithMessage("TELEFON BILGISI BOS OLAMAZ.")
              .MaximumLength(13).WithMessage("TELEFON BILGISI 13 KARAKTERDEN FAZLA OLAMAZ.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("EPOSTA BILGISI BOS OLAMAZ.")
                .MaximumLength(150).WithMessage("EPOSTA BILGISI 150 KARAKTERDEN FAZLA OLAMAZ.")
                .EmailAddress().WithMessage("GECERLI BIR E POSTA ADRESI GIRINIZ.");

            RuleFor(x => x.Birthday)
                .NotEmpty().WithMessage("DOGUM TARIHI BILGISI BOS OLAMAZ.");

            RuleFor(x => x.Gender)
               .NotEmpty().WithMessage("CINSIYET BILGISI BOS OLAMAZ.")
               .IsInEnum().WithMessage("GECERLI BIR CINSIYET BILGISI GIRINIZ.");

            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("KULLANICI ADI BILGISI BOS OLAMAZ.")
               .MaximumLength(10).WithMessage("KULLANICI ADI EN FAZLA 10 KARAKTER OLABILIR.");

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("PAROLA BILGISI BOS OLAMAZ.")
               .MaximumLength(10).WithMessage("PAROLA EN FAZLA 10 KARAKTER OLABILIR.");

            RuleFor(x => x.PasswordAgain)
             .NotEmpty().WithMessage("PAROLA TEKRAR BILGISI BOS OLAMAZ.")
             .MaximumLength(10).WithMessage("PAROLA TEKRAR EN FAZLA 10 KARAKTER OLABILIR.");

            RuleFor(x => x.Password)
                .Matches(x => x.PasswordAgain).WithMessage("PAROLA VE PAROLA TEKRAR BILGISI ESLESMIYOR.");



        }
    }
}
