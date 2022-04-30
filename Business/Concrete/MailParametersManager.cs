using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstarct;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MailParametersManager : IMailParametersService
    {
        private readonly IMailParametersDal _mailParametersDal;

        public MailParametersManager(IMailParametersDal mailParametersDal)
        {
            _mailParametersDal = mailParametersDal;
        }

        public IDataResult<MailParameters> Get(int companyId)
        {
            return new SuccessDataResult<MailParameters>(_mailParametersDal.Get(m => m.CompanyId == companyId));
        }

        public IResult Update(MailParameters mailParameters)
        {
            var result = Get(mailParameters.CompanyId);
            if (result==null)
            {
                _mailParametersDal.Add(mailParameters);
            }
            else
            {
                result.Data.SMTP = mailParameters.SMTP;
                result.Data.Port = mailParameters.Port;
                result.Data.SSL = mailParameters.SSL;
                result.Data.EMail = mailParameters.EMail;
                result.Data.Password = mailParameters.Password;
                _mailParametersDal.Update(result.Data);
            }
            return new SuccessResult();
        }

       
    }
}
