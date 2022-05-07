using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountReconcilationsDetailsController : ControllerBase
    {
        private readonly IAccountReconcilationsDetailsService _accountReconcilationsDetailsService;

        public AccountReconcilationsDetailsController(IAccountReconcilationsDetailsService accountReconcilationsDetailsService)
        {
            _accountReconcilationsDetailsService = accountReconcilationsDetailsService;
        }
        [HttpPost("add")]
        public IActionResult Add(AccountReconcilationsDetail accountReconcilations)
        {
            var result = _accountReconcilationsDetailsService.Add(accountReconcilations);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(AccountReconcilationsDetail accountReconcilations)
        {
            var result = _accountReconcilationsDetailsService.Update(accountReconcilations);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(AccountReconcilationsDetail accountReconcilations)
        {
            var result = _accountReconcilationsDetailsService.Delete(accountReconcilations);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("getById")]
        public IActionResult GetById(int id)
        {
            var result = _accountReconcilationsDetailsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("getList")]
        public IActionResult GetList(int companyId)
        {
            var result = _accountReconcilationsDetailsService.GetList(companyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}

