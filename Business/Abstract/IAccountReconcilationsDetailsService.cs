using Core.Utilities.Results.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAccountReconcilationsDetailsService
    {
        IResult Add(AccountReconcilationsDetail accountReconcilationsDetails);
        IResult Delete(AccountReconcilationsDetail accountReconcilationsDetails);
        IResult Update(AccountReconcilationsDetail accountReconcilationsDetails);
        IDataResult<AccountReconcilationsDetail> GetById(int id);
        IDataResult<List<AccountReconcilationsDetail>> GetList(int id);
    }
}
