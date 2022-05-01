using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUsersService
    {
        List<OperationClaims> GetClaims(User user,int companyId);
        void Add(User user);
        void Update(User user);
        User GetById(int Id);
        User GetByMail(string mail);
        User GetByMailConfirmValue(string value);
    }
}
