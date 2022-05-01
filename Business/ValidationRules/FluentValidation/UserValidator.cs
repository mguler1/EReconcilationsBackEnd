using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage("Mail Adresi Adı Boş Olamaz");
            RuleFor(x => x.UserEmail).EmailAddress().WithMessage("Mail Adresi Geçerli Değil");
        }
    }
}
