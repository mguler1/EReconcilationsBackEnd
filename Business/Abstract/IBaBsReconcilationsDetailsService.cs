using Core.Utilities.Results.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaBsReconcilationsDetailsService
    {
        IResult Add(BaBsReconcilationsDetails baBsReconcilationsDetails);
        IResult Delete(BaBsReconcilationsDetails baBsReconcilationsDetails);
        IResult Update(BaBsReconcilationsDetails baBsReconcilationsDetails);
        IDataResult<BaBsReconcilationsDetails> GetById(int id);
        IDataResult<List<BaBsReconcilationsDetails>> GetList(int id);
    }
}
