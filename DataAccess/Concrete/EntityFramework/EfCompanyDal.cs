using Core.DataAccess.EntityFramewrok;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal: EfEntityRepoistoryBase<Companies,ContextDb>,ICompanyDal
    {
    }
}
