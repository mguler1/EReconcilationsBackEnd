using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaBsReconcilationDetailController : ControllerBase
    {

        private readonly IBaBsReconcilationsDetailsService _baBsReconcilationsDetailsService;

        public BaBsReconcilationDetailController(IBaBsReconcilationsDetailsService baBsReconcilationsDetailsService)
        {
            _baBsReconcilationsDetailsService = baBsReconcilationsDetailsService;
        }
        [HttpPost("add")]
        public IActionResult Add(BaBsReconcilationsDetails baBsReconcilation)
        {
            var result = _baBsReconcilationsDetailsService.Add(baBsReconcilation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(BaBsReconcilationsDetails baBsReconcilation)
        {
            var result = _baBsReconcilationsDetailsService.Update(baBsReconcilation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(BaBsReconcilationsDetails baBsReconcilation)
        {
            var result = _baBsReconcilationsDetailsService.Delete(baBsReconcilation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("getById")]
        public IActionResult GetById(int id)
        {
            var result = _baBsReconcilationsDetailsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("getList")]
        public IActionResult GetList(int companyId)
        {
            var result = _baBsReconcilationsDetailsService.GetList(companyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}

