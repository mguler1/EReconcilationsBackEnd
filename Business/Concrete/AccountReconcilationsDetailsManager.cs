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
    public class AccountReconcilationsDetailsManager : IAccountReconcilationsDetailsService
    {
        private readonly IAccountReconcilationsDetailDal _accountReconcilationsDetailDal;
        public IResult Add(AccountReconcilationsDetail accountReconcilationsDetails)
        {
            _accountReconcilationsDetailDal.Add(accountReconcilationsDetails);
            return new SuccessResult();
        }

        public IResult Delete(AccountReconcilationsDetail accountReconcilationsDetails)
        {
            _accountReconcilationsDetailDal.Delete(accountReconcilationsDetails);
            return new SuccessResult();
        }

        public IDataResult<AccountReconcilationsDetail> GetById(int id)
        {
            return new SuccessDataResult<AccountReconcilationsDetail>(_accountReconcilationsDetailDal.Get(x => x.AccountReconcilationsId == id));

        }

        public IDataResult<List<AccountReconcilationsDetail>> GetList(int id)
        {
            return new SuccessDataResult<List<AccountReconcilationsDetail>>(_accountReconcilationsDetailDal.GetList(x => x.AccountReconcilationsId == id));

        }

        public IResult Update(AccountReconcilationsDetail accountReconcilationsDetails)
        {
            _accountReconcilationsDetailDal.Update(accountReconcilationsDetails);
            return new SuccessResult();
        }
    }
}
