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
    public class BaBsReconcilationsDetailsManager: IBaBsReconcilationsDetailsService
    {

        private readonly IBaBsReconcilationsDetailDal _baBsReconcilationDal;

        public BaBsReconcilationsDetailsManager(IBaBsReconcilationsDetailDal baBsReconcilationDal)
        {
            _baBsReconcilationDal = baBsReconcilationDal;
        }

        public IResult Add(BaBsReconcilationsDetails baBsReconcilationsDetails)
        {
            _baBsReconcilationDal.Add(baBsReconcilationsDetails);
            return new SuccessResult();
        }

        public IResult Delete(BaBsReconcilationsDetails baBsReconcilationsDetails)
        {

            _baBsReconcilationDal.Delete(baBsReconcilationsDetails);
            return new SuccessResult();
        }

        public IDataResult<BaBsReconcilationsDetails> GetById(int id)
        {
            return new SuccessDataResult<BaBsReconcilationsDetails>(_baBsReconcilationDal.Get(x => x.BaBsReconcilationsId== id));
        }

        public IDataResult<List<BaBsReconcilationsDetails>> GetList(int companyId)
        {
            return new SuccessDataResult<List<BaBsReconcilationsDetails>>(_baBsReconcilationDal.GetList(x => x.BaBsReconcilationsDetailsId == companyId));
        }

        public IResult Update(BaBsReconcilationsDetails baBsReconcilationsDetails)
        {

            _baBsReconcilationDal.Update(baBsReconcilationsDetails);
            return new SuccessResult();
        }
    }
}

