using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountReconcilationsController : ControllerBase
    {
        private readonly IAccountReconcilationsService _accountReconcilationsService;

        public AccountReconcilationsController(IAccountReconcilationsService accountReconcilationsService)
        {
            _accountReconcilationsService = accountReconcilationsService;
        }
        [HttpPost("add")]
        public IActionResult Add(AccountReconcilations accountReconcilations)
        {
            var result = _accountReconcilationsService.Add(accountReconcilations);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(AccountReconcilations accountReconcilations)
        {
            var result = _accountReconcilationsService.Update(accountReconcilations);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(AccountReconcilations accountReconcilations)
        {
            var result = _accountReconcilationsService.Delete(accountReconcilations);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("getById")]
        public IActionResult GetById(int id)
        {
            var result = _accountReconcilationsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("getList")]
        public IActionResult GetList(int companyId)
        {
            var result = _accountReconcilationsService.GetList(companyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
