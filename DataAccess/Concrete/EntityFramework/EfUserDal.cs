using Core.DataAccess.EntityFramewrok;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepoistoryBase<User, ContextDb>, IUserDal
    {
        public List<OperationClaims> GetClaims(User user, int companyId)
        {
            using (var context = new ContextDb())
            {
                var result = from operationClaims in context.OperationClaims
                             join userOperationClaims in context.UserOperationClaims
                             on operationClaims.OperationClaimsId equals userOperationClaims.OperationClaimsId
                             where userOperationClaims.CompanyId == companyId && userOperationClaims.UserId == user.UserId
                             select new OperationClaims
                             {
                                 OperationClaimsId = operationClaims.OperationClaimsId,
                                 Name = operationClaims.Name,
                             };
                return result.ToList();
            }
        }
    }
}
