using Core.DataAccess.EntityFramewrok;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal : EfEntityRepoistoryBase<Companies, ContextDb>, ICompanyDal
    {
        public void UserCompanyAdd(int userId, int companyId)
        {
          using(var context=new ContextDb())
            {
                UserCompanies userCompany = new UserCompanies()
                {
                    UserId = userId,
                    CompanyId = companyId,
                    IsActive=true
                };
                context.UserCompanies.Add(userCompany);
                context.SaveChanges();
            }
        }
    }
}
