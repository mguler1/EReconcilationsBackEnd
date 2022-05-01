﻿using Core.Entities.Concrete;
using Core.Utilities.Results.Abstarct;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<UserCompanyDto> Regiter(UserForRegisterDto userForRegisterDto ,string passord, Companies company);
        IDataResult<User> RegiterSecondAccount(UserForRegisterDto userForRegisterDto ,string passord,int companyId);
        IDataResult<User> Login(UserForLogin userForLoginDto);
        IDataResult<User> GetByMailConfirmValue(string value);
        IDataResult<User> GetById(int Id);
        IResult UserExist(string email);
        IResult Update(User user);
        IResult CompanyExist(Companies company);
        IResult SendConfirmEmail(User user);
        IDataResult<AccessToken> CreateAccessToken(User user,int companyId);
        IDataResult<UserCompanies> GetCompany(int userId);
    }
}
