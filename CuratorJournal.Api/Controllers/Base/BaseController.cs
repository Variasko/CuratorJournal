using Microsoft.AspNetCore.Mvc;
using CuratorJournal.DataAccess.Services.Interfaces.Base;
using System.Threading.Tasks;

namespace CuratorJournal.Api.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T> : ControllerBase where T : class
    {
        private readonly IServiceBase<T> _service;

        protected BaseController(IServiceBase<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] T model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _service.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = GetId(created) }, created);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] T model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        // Получение ID из объекта (можно улучшить через рефлексию или интерфейс)
        private int GetId(T entity)
        {
            var property = typeof(T).GetProperty("Id");
            return property != null ? (int)property.GetValue(entity)! : -1;
        }
    }
}