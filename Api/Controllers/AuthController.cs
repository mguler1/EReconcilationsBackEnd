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
        public IActionResult RegisterSecondAccount(UserForRegisterDto userForRegisterDto, int companyId)
        {
            var userExist = _authService.UserExist(userForRegisterDto.EMail);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var registerResult = _authService.RegiterSecondAccount(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data, companyId);
           
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
            var result = _authService.CreateAccessToken(userToLogin.Data, 0);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(userToLogin.Message);
        }
    }
}
