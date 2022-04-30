using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Results.Abstarct;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUsersService _usersService;
        private readonly ICompanyService _companyService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUsersService usersService, ITokenHelper tokenHelper, ICompanyService companyService)
        {
            _usersService = usersService;
            _tokenHelper = tokenHelper;
            _companyService = companyService;
        }

        public IResult CompanyExist(Companies company)
        {
            var result = _companyService.ComapnyExist(company);
            if (result != null)
            {
                return new ErrorResult(Messages.CompanyExist);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user, int companyId)
        {
            var claims = _usersService.GetClaims(user, companyId);
            var accessToken = _tokenHelper.CreateToken(user, claims, companyId);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Login(UserForLogin userForLoginDto)
        {
            var userToCheck = _usersService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessFulLogin);
        }

        public IDataResult<UserCompanyDto> Regiter(UserForRegisterDto userForRegisterDto, string passord, Companies company)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(passord, out passwordHash, out passwordSalt);
            var user = new User()
            {
                UserEmail = userForRegisterDto.EMail,
                AddedAt = DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                MailConfirmDate = DateTime.Now,
                MailConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserName = userForRegisterDto.Name

            };
            _usersService.Add(user);
            _companyService.Add(company);
            _companyService.UserCompanyAdd(user.UserId, company.CompanyId);
            UserCompanyDto userCompanyDto = new UserCompanyDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                AddedAt = user.AddedAt,
                CompanyId = company.CompanyId,
                IsActive = true,
                MailConfirm = user.MailConfirm,
                MailConfirmDate = user.MailConfirmDate,
                MailConfirmValue = user.MailConfirmValue,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };
            return new SuccessDataResult<UserCompanyDto>(userCompanyDto, Messages.SuccessRegister);
        }

        public IDataResult<User> RegiterSecondAccount(UserForRegisterDto userForRegisterDto, string passord)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(passord, out passwordHash, out passwordSalt);
            var user = new User()
            {
                UserEmail = userForRegisterDto.EMail,
                AddedAt = DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                MailConfirmDate = DateTime.Now,
                MailConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserName = userForRegisterDto.Name

            };
            _usersService.Add(user);
            return new SuccessDataResult<User>(user, Messages.SuccessRegister);
        }

        public IResult UserExist(string email)
        {
            if (_usersService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}