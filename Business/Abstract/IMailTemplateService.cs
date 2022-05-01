using Core.Utilities.Results.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMailTemplateService
    {
        IResult Add(MailTemplates mailTemplates);
        IResult Update(MailTemplates mailTemplates);
        IResult Delete(MailTemplates mailTemplates);
        IDataResult <MailTemplates> Get(int id);
        IDataResult <MailTemplates> GetByTemplateName(string name ,int CompanyId);
        IDataResult <List<MailTemplates>> GetAll(int companyId);
    }
}
