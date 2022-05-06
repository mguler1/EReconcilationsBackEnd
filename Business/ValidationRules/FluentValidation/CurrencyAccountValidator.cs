using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public  class CurrencyAccountValidator:AbstractValidator<CurrencyAccount>
    {
        public CurrencyAccountValidator()
        {
            RuleFor(x => x.CurrencyAccountName).NotEmpty().WithMessage("Şirket Adı Boş Olamaz");
        }
    }
}
