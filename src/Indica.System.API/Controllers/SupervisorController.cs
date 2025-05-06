using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupervisorController : ControllerBase
    {
        private readonly ILogger<SupervisorController> _logger;
        private readonly ISupervisorService _supervisorService;
        public SupervisorController(ISupervisorService supervisorService, ILogger<SupervisorController> logger)
        {
            _logger = logger;
            _supervisorService = supervisorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employers = await _supervisorService.GetAllAsync();
            return Ok(employers);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employer = await _supervisorService.GetByIdAsync(id);
            return Ok(employer);
        }
        [HttpPost]
        public async Task<IActionResult> Post(SupervisorDTO employer)
        {
            await _supervisorService.AddAsync(employer);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> Put(SupervisorDTO employer)
        {
            await _supervisorService.UpdateAsync(employer);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _supervisorService.DeleteAsync(id);
            return NoContent();
        }
    }
}