using Microsoft.AspNetCore.Mvc;
using Indica.Productivity.Application;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Web.Api.Controllers
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

        [HttpGet("Batch")]
        public virtual async Task<IActionResult> GetMany()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("Batch")]
        public virtual async Task<IActionResult> PostMany([FromBody] List<TDto> list)
        {
            await _service.AddRangeAsync(list);
            return Created();
        }

        [HttpPut("Batch")]
        public virtual async Task<IActionResult> PutMany([FromBody] List<TDto> list)
        {
            await _service.UpdateRangeAsync(list);
            return NoContent();
        }

        [HttpDelete("Batch")]
        public virtual async Task<IActionResult> DeleteMany([FromBody] List<TDto> list)
        {
            await _service.DeleteRangeAsync(list);
            return NoContent();
        }

        [HttpPost("Upload")]
        public virtual async Task<IActionResult> PostFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Arquivo enviado está vazio!");
            }
            await _service.AddRangeAsync(file.OpenReadStream(), file.FileName);
            return Created();
        }
    }
}
