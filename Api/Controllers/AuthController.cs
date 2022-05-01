using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register(UserAndCompanyRegisterDto userAndCompanyRegister)
        {
            var userExist = _authService.UserExist(userAndCompanyRegister.UserForRegisterDto.EMail);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var companyExist = _authService.CompanyExist(userAndCompanyRegister.Company);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var registerResult = _authService.Regiter(userAndCompanyRegister.UserForRegisterDto, userAndCompanyRegister.UserForRegisterDto.Password, userAndCompanyRegister.Company);
            var result = _authService.CreateAccessToken(registerResult.Data, registerResult.Data.CompanyId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(registerResult.Message);
        }
        [HttpPost("registerSecondAccount")]
        public IActionResult RegisterSecondAccount(UserForRegisterToSecondAccountDto userForRegisterToSecondAccountDto)
        {
            var userExist = _authService.UserExist(userForRegisterToSecondAccountDto.EMail);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var registerResult = _authService.RegiterSecondAccount(userForRegisterToSecondAccountDto, userForRegisterToSecondAccountDto.Password, userForRegisterToSecondAccountDto.CompanyId);
            var result = _authService.CreateAccessToken(registerResult.Data, userForRegisterToSecondAccountDto.CompanyId);
           
            return BadRequest(registerResult.Message);
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLogin userForLogin)
        {
            var userToLogin = _authService.Login(userForLogin);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            if (userToLogin.Data.IsActive)
            {
                var userCompany = _authService.GetCompany(userToLogin.Data.UserId).Data;
                var result = _authService.CreateAccessToken(userToLogin.Data, userCompany.CompanyId);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
            }
            else
            {
                return BadRequest(userToLogin.Message);
            }
            return BadRequest("Kullanıcı Pasif Durumdadır");

        }

        [HttpGet("confirmUser")]
        public IActionResult ConfirmUser(string value)
        {
            var user = _authService.GetByMailConfirmValue(value).Data;
            user.MailConfirm = true;
            user.MailConfirmDate = DateTime.Now;
            var result= _authService.Update(user);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }

        [HttpGet("sendConfirmEmail")]
        public IActionResult SendConfirmEMail(int userId)
        {
            var user = _authService.GetById(userId).Data;
            var result=_authService.SendConfirmEmail(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
