using Microsoft.AspNetCore.Mvc;
using Indica.System.Application;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class GenericController<TDto, TEntity> : ControllerBase
        where TDto : EntityBaseDTO
        where TEntity : EntityBase
    {
        private readonly ILogger _logger;
        private readonly IBaseService<TDto, TEntity> _service;

        protected GenericController(IBaseService<TDto, TEntity> service, ILogger logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto dto)
        {
            await _service.AddAsync(dto);
            return Created();
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TDto dto)
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
