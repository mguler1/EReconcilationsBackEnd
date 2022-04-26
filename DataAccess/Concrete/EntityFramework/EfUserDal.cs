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
    public class EfUserDal: EfEntityRepoistoryBase<User, ContextDb>, IUserDal
    {
    }
}
