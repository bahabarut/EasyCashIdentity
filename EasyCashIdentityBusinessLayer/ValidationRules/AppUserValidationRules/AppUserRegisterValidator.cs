using EasyCashIdentityDTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityBusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.name).MaximumLength(30).WithMessage("Lütfen En Fazla 30 Karakter Girişi Yapınız!");
            RuleFor(x => x.name).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız!");
            RuleFor(x => x.surname).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.email).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.email).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz!");
            RuleFor(x => x.username).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.image).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.password).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.confirmpassword).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.confirmpassword).Equal(y=>y.password).WithMessage("Şifreleriniz Eşleşmiyor!");
        }
    }
}
