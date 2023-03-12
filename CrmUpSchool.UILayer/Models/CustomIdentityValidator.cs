using Microsoft.AspNetCore.Identity;

namespace CrmUpSchool.UILayer.Models
{
    public class CustomIdentityValidator: IdentityErrorDescriber
    {
        //identityerror sınıfına bağlı hataları kullanmak için, mevcutta olan yapıyı istediğin formatta kullanmak için override
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifre en az {length} karakter olmalıdır."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen en az 1 küçük harf giriniz."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lütden en az 1 biyük harf girin."
            };              
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "En az 1 tane sayı giriniz"
            };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                    Code= "DuplicateEmail",
                    Description=$"ilgili mail adresi:{email} zaten sistemde mevcut, lütfen farklı bir mail adresi ile kayıt ol."
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $"ilgili kullanıcı adresi:{userName} zaten sistemde mevcut, lütfen farklı bir kullanıcı adı ile kayıt ol."
            };
        }
    }
}
