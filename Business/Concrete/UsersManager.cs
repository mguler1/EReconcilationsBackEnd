using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Entities.Concrete;
using Core.Extensions.Aspects.Autofact.Validation;
using DataAccess.Abstract;
using FluentValidation;
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
        [ValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {
            UserValidator userValid = new UserValidator();
            var result = userValid.Validate(user);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            _userDal.Add(user);
        }

        public User GetById(int Id)
        {
            return _userDal.Get(x => x.UserId == Id);
        }

        public User GetByMail(string mail)
        {
            return _userDal.Get(p => p.UserEmail == mail);
        }

        public User GetByMailConfirmValue(string value)
        {
            return _userDal.Get(p=>p.MailConfirmValue==value);
        }

        public List<OperationClaims> GetClaims(User user,int companyId)
        {
            return _userDal.GetClaims(user, companyId);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
