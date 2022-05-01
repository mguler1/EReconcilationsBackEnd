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
        private readonly IMailService _mailService;
        private readonly IMailParametersService _mailParametersService;
        private readonly IMailTemplateService _mailTemplateService;
        public AuthManager(IUsersService usersService, ICompanyService companyService, ITokenHelper tokenHelper, IMailService mailService, IMailParametersService mailParametersService, IMailTemplateService mailTemplateService)
        {
            _usersService = usersService;
            _companyService = companyService;
            _tokenHelper = tokenHelper;
            _mailService = mailService;
            _mailParametersService = mailParametersService;
            _mailTemplateService = mailTemplateService;
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

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_usersService.GetById(Id));
        }

        public IDataResult<User> GetByMailConfirmValue(string value)
        {
            return new SuccessDataResult<User>(_usersService.GetByMailConfirmValue(value));
        }

        public IDataResult<UserCompanies> GetCompany(int userId)
        {
            return new SuccessDataResult<UserCompanies>(_companyService.GetCompany(userId).Data);
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
            sendConfirmEmail(user);
            return new SuccessDataResult<UserCompanyDto>(userCompanyDto, Messages.SuccessRegister);
            void sendConfirmEmail(User user )
            {
                string subject = "Kullanıcı Onay Maili";
                string body = "Sisteme Kayıt oldunuz Tamamlamak için Linke tıkla";
                string link = "https://localhost:7293/api/Auth/confirmUser?value" + user.MailConfirmValue;
                string linkDescription = "Kaydı Onaylamak için tıkla";

                var mailTemplate = _mailTemplateService.GetByTemplateName("Register", 4);
                string templateBody = mailTemplate.Data.Values;
                templateBody = templateBody.Replace("{{title}}", subject);
                templateBody = templateBody.Replace("{{message}}", body);
                templateBody = templateBody.Replace("{{link}}", link);
                templateBody = templateBody.Replace("{{linkDescription}}", linkDescription);
                //sonra açılacak
                //var mailParameters = _mailParametersService.Get(4);
                //SendMailDto sendMailDto = new SendMailDto()
                //{
                //    mailParameters = mailParameters.Data,
                //    email = user.UserEmail,
                //    subject = "",
                //    body = templateBody
                //};
                //_mailService.SendMail(sendMailDto);
                user.MailConfirmDate = DateTime.Now;
                _usersService.Update(user);
            }
         
        }

        public IDataResult<User> RegiterSecondAccount(UserForRegisterDto userForRegisterDto, string passord,int companyId)
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
            _companyService.UserCompanyAdd(user.UserId, companyId);
            SendConfirmEmail(user);
            return new SuccessDataResult<User>(user, Messages.SuccessRegister);
        }

        public IResult SendConfirmEmail(User user)
        {
            if (user.MailConfirm==true)
            {
                return new ErrorResult(Messages.MailAllReadyConfirm);
            }
            DateTime confirmMailDate = user.MailConfirmDate;
            DateTime now = DateTime.Now;
            if (confirmMailDate.ToShortDateString()==now.ToShortDateString())
            {
                if (confirmMailDate.Hour==now.Hour && confirmMailDate.AddMinutes(5).Minute <= now.Minute)
                {
                    SendConfirmEmail(user);
                    return new SuccessResult();
                }
                else
                {
                    return new ErrorResult(Messages.MailAllReadyConfirm);
                }
              
            }
            SendConfirmEmail(user);
            return new SuccessResult();

        }
      
        public IResult Update(User user)
        {
            _usersService.Update(user);
            return new SuccessResult();
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