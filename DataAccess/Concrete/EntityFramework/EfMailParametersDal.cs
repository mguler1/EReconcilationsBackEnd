using Core.DataAccess.EntityFramewrok;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMailParametersDal: EfEntityRepoistoryBase<MailParameters, ContextDb>, IMailParametersDal
    {
    }
}
