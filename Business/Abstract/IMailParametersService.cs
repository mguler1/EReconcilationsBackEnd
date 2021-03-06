using Core.Utilities.Results.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMailParametersService
    {
        IResult Update(MailParameters mailParameters);
        IDataResult< MailParameters> Get(int companyId);
    }
}
