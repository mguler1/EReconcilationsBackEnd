using Core.Entities.Concrete;
using Core.Utilities.Results.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IResult Add(Companies companies);
        IResult Update(Companies companies);
        IResult AddCompanyAddUserCompany(CompanyDto companyDto);
        IDataResult<List<Companies>> GetList();
        IDataResult<UserCompanies> GetCompany(int userId);
        IDataResult<Companies> GetById(int Id);
        IResult ComapnyExist(Companies companies);
        IResult UserCompanyAdd(int userId,int companyId);
    }
}
