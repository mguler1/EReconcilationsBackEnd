using Core.Entities.Concrete;
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
        IDataResult<User> RegiterSecondAccount(UserForRegisterDto userForRegisterDto ,string passord);
        IDataResult<User> Login(UserForLogin userForLoginDto);
        IResult UserExist(string email);
        IResult CompanyExist(Companies company);
        IDataResult<AccessToken> CreateAccessToken(User user,int companyId);
    }
}
