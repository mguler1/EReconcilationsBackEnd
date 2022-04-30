using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailParameterController : ControllerBase
    {
        private readonly IMailParametersService _mailParametersService;

        public MailParameterController(IMailParametersService mailParametersService)
        {
            _mailParametersService = mailParametersService;
        }
        [HttpPost("update")]
        public IActionResult MailParameter (MailParameters mailParameters)
        {
            var result=_mailParametersService.Update(mailParameters);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
