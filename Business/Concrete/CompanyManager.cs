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
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IResult Add(Companies companies)
        {
            _companyDal.Add(companies);
            return new SuccessResult(true,Messages.AddedCompany);
        }

        public IResult ComapnyExist(Companies companies)
        {
            var result = _companyDal.Get(c => c.CompanyName == companies.CompanyName && c.TaxDepartment == companies.TaxDepartment && c.TaxIdNumber == companies.TaxIdNumber);
            if (result!=null)
            {
                return new ErrorResult(Messages.CompanyExist);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Companies>> GetList()
        {
            return new SuccessDataResult<List<Companies>>(_companyDal.GetList());
        }

        public IResult UserCompanyAdd(int userId, int companyId)
        {
          _companyDal.UserCompanyAdd(userId, companyId);
            return new SuccessResult();
        }
    }
}
