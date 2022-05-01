using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyValidator : AbstractValidator<Companies>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Şirket Adı Boş Olamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Şirket Adresi Boş Olamaz");
        }
    }
}
