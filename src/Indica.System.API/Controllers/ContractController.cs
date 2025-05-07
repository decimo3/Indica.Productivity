using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly ILogger<ContractController> _logger;
        private readonly IContractService _contractService;
        public ContractController(IContractService contractService, ILogger<ContractController> logger)
        {
            _logger = logger;
            _contractService = contractService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contracts = await _contractService.GetAllAsync();
            return Ok(contracts);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(double id)
        {
            var contract = await _contractService.GetByIdAsync(id);
            return Ok(contract);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ContractDTO contract)
        {
            await _contractService.AddAsync(contract);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> Put(ContractDTO contract)
        {
            await _contractService.UpdateAsync(contract);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(double id)
        {
            await _contractService.DeleteAsync(id);
            return NoContent();
        }
    }
}
