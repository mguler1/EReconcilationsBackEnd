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
    public class BaBsReconcilationsManager: IBaBsReconcilationsService
    {
        private readonly IBaBsReconcilationDal _baBsReconcilationDal;
        private readonly ICurrencyAccountDal _currencyAccountDal;

        public BaBsReconcilationsManager(IBaBsReconcilationDal baBsReconcilationDal, ICurrencyAccountDal currencyAccountDal)
        {
            _baBsReconcilationDal = baBsReconcilationDal;
            _currencyAccountDal = currencyAccountDal;
        }

        public IResult Add(BaBsReconcilation baBsReconcilation)
        {
            _baBsReconcilationDal.Add(baBsReconcilation);
            return new SuccessResult();
        }

        public IResult Delete(BaBsReconcilation BaBsReconcilation)
        {

            _baBsReconcilationDal.Delete(BaBsReconcilation);
            return new SuccessResult();
        }

        public IDataResult<BaBsReconcilation> GetById(int id)
        {
            return new SuccessDataResult<BaBsReconcilation>(_baBsReconcilationDal.Get(x => x.BaBsReconcilationId == id));
        }

        public IDataResult<List<BaBsReconcilation>> GetList(int companyId)
        {
            return new SuccessDataResult<List<BaBsReconcilation>>(_baBsReconcilationDal.GetList(x => x.CompanyId == companyId));
        }

        public IResult Update(BaBsReconcilation baBsReconcilation)
        {

            _baBsReconcilationDal.Update(baBsReconcilation);
            return new SuccessResult();
        }
    }
}
