using Core.Utilities.Results.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAccountReconcilationsService
    {
        IResult Add(AccountReconcilations accountReconcilations);
        IResult Delete(AccountReconcilations accountReconcilations);
        IResult Update(AccountReconcilations accountReconcilations);
        IDataResult<AccountReconcilations> GetById(int id);
        IDataResult<List<AccountReconcilations>>GetList(int companyId);
    }
}
