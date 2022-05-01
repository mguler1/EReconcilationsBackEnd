using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICompanyDal:IEntityRepository<Companies>
    {
        void UserCompanyAdd(int userId, int companyId);
        UserCompanies GetCompany(int userId);
    }
}
