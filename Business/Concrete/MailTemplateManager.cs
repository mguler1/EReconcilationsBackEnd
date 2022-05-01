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
    public class MailTemplateManager : IMailTemplateService
    {
        private readonly IMailTemplateDal _mailTemplateDal;

        public MailTemplateManager(IMailTemplateDal mailTemplateDal)
        {
            _mailTemplateDal = mailTemplateDal;
        }

        public IResult Add(MailTemplates mailTemplates)
        {
            _mailTemplateDal.Add(mailTemplates);
            return new SuccessResult();
        }

        public IResult Delete(MailTemplates mailTemplates)
        {
            _mailTemplateDal.Delete(mailTemplates);
            return new SuccessResult();
        }

        public IDataResult<MailTemplates> Get(int id)
        {
            return new SuccessDataResult<MailTemplates>(_mailTemplateDal.Get(m => m.Id == id));
        }

        public IDataResult<List<MailTemplates>> GetAll(int companyId)
        {
            return new SuccessDataResult<List<MailTemplates>>(_mailTemplateDal.GetList(m => m.CompanyId == companyId));
        }

        public IDataResult<MailTemplates> GetByTemplateName(string name, int CompanyId)
        {
            return new SuccessDataResult<MailTemplates>(_mailTemplateDal.Get(m => m.Type == name && m.CompanyId==CompanyId));
        }

        public IResult Update(MailTemplates mailTemplates)
        {
            _mailTemplateDal.Update(mailTemplates);
            return new SuccessResult();
        }
    }
}
