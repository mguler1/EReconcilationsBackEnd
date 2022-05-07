using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaBsReconcilationController : ControllerBase
    {
        private readonly IBaBsReconcilationsService _baBsReconcilationsService;

        public BaBsReconcilationController(IBaBsReconcilationsService baBsReconcilationsService)
        {
            _baBsReconcilationsService = baBsReconcilationsService;
        }
        [HttpPost("add")]
        public IActionResult Add(BaBsReconcilation baBsReconcilation)
        {
            var result = _baBsReconcilationsService.Add(baBsReconcilation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(BaBsReconcilation baBsReconcilation)
        {
            var result = _baBsReconcilationsService.Update(baBsReconcilation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(BaBsReconcilation baBsReconcilation)
        {
            var result = _baBsReconcilationsService.Delete(baBsReconcilation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("getById")]
        public IActionResult GetById(int id)
        {
            var result = _baBsReconcilationsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("getList")]
        public IActionResult GetList(int companyId)
        {
            var result = _baBsReconcilationsService.GetList(companyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
