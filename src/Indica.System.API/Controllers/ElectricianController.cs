using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectricianController : ControllerBase
    {
        private readonly ILogger<ElectricianController> _logger;
        private readonly IElectricianService _eletricianService;
        public ElectricianController(IElectricianService eletricianService, ILogger<ElectricianController> logger)
        {
            _logger = logger;
            _eletricianService = eletricianService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employers = await _eletricianService.GetAllAsync();
            return Ok(employers);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employer = await _eletricianService.GetByIdAsync(id);
            return Ok(employer);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ElectricianDTO employer)
        {
            await _eletricianService.AddAsync(employer);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> Put(ElectricianDTO employer)
        {
            await _eletricianService.UpdateAsync(employer);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eletricianService.DeleteAsync(id);
            return NoContent();
        }
    }
}