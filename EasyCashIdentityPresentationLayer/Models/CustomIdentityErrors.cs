using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EasyCashIdentityPresentationLayer.Models
{
    public class CustomIdentityErrors : IdentityErrorDescriber
    {

        public override IdentityError PasswordTooShort(int length) => new IdentityError { Code = nameof(PasswordTooShort), Description = $"Şifre {length} Karakterden Uzun Olmalı!" };
        public override IdentityError PasswordRequiresLower() => new IdentityError { Code = nameof(PasswordRequiresLower), Description = $"Şifre En Az 1 Küçük Harf İçermelidir!" };
        public override IdentityError PasswordRequiresUpper() => new IdentityError { Code = nameof(PasswordRequiresUpper), Description = $"Şifre En Az 1 Büyük Harf İçermelidir!" };
        public override IdentityError PasswordRequiresNonAlphanumeric() => new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = $"Şifre En Az 1 Karakter İçermelidir!" };
    }
}
