using Core.Utilities.Results.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaBsReconcilationsService
    {
        IResult Add(BaBsReconcilation baBsReconcilation);
        IResult Delete(BaBsReconcilation baBsReconcilation);
        IResult Update(BaBsReconcilation baBsReconcilation);
        IDataResult<BaBsReconcilation> GetById(int id);
        IDataResult<List<BaBsReconcilation>> GetList(int companyId);
    }
}
