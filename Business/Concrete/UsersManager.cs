using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UsersManager : IUsersService
    {
        private IUserDal _userDal ;

        public UsersManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string mail)
        {
            return _userDal.Get(p => p.UserEmail == mail);
        }

        public List<OperationClaims> GetClaims(User user,int companyId)
        {
            return _userDal.GetClaims(user, companyId);
        }
    }
}
