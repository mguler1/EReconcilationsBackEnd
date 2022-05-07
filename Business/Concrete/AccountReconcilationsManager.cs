using Business.Abstract;
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
    public class AccountReconcilationsManager : IAccountReconcilationsService
    {
        private readonly IAccountReconcilationDal _accountReconcilationDal;

        public AccountReconcilationsManager(IAccountReconcilationDal accountReconcilationDal)
        {
            _accountReconcilationDal = accountReconcilationDal;
        }

        public IResult Add(AccountReconcilations accountReconcilations)
        {
            _accountReconcilationDal.Add(accountReconcilations);
            return new SuccessResult();
        }

        public IResult Delete(AccountReconcilations accountReconcilations)
        {

            _accountReconcilationDal.Delete(accountReconcilations);
            return new SuccessResult();
        }

        public IDataResult<AccountReconcilations> GetById(int id)
        {
            return new SuccessDataResult<AccountReconcilations>(_accountReconcilationDal.Get(x => x.AccountReconcilationsId == id));
        }

        public IDataResult<List<AccountReconcilations>> GetList(int companyId)
        {
            return new SuccessDataResult<List<AccountReconcilations>>(_accountReconcilationDal.GetList(x=>x.CompanyId==companyId));
        }

        public IResult Update(AccountReconcilations accountReconcilations)
        {

            _accountReconcilationDal.Update(accountReconcilations);
            return new SuccessResult();
        }
    }
}
