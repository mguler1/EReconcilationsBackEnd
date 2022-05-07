using Business.Abstract;
using Core.Extensions.Aspects.Caching;
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
        [CacheRemoveAspect("IAccountReconcilationsService.Get")]
        public IResult Add(AccountReconcilations accountReconcilations)
        {
            _accountReconcilationDal.Add(accountReconcilations);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IAccountReconcilationsService.Get")]
        public IResult Delete(AccountReconcilations accountReconcilations)
        {

            _accountReconcilationDal.Delete(accountReconcilations);
            return new SuccessResult();
        }

        public IDataResult<AccountReconcilations> GetById(int id)
        {
            return new SuccessDataResult<AccountReconcilations>(_accountReconcilationDal.Get(x => x.AccountReconcilationsId == id));
        }
        [CacheAspect(60)]
        public IDataResult<List<AccountReconcilations>> GetList(int companyId)
        {
            return new SuccessDataResult<List<AccountReconcilations>>(_accountReconcilationDal.GetList(x=>x.CompanyId==companyId));
        }
        [CacheRemoveAspect("IAccountReconcilationsService.Get")]
        public IResult Update(AccountReconcilations accountReconcilations)
        {

            _accountReconcilationDal.Update(accountReconcilations);
            return new SuccessResult();
        }
    }
}
