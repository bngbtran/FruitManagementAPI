using FruitManagementAPI.Models;
using FruitManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FruitsController : ControllerBase
    {
        private readonly FruitService _service;

        public FruitsController(FruitService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fruit = await _service.GetByIdAsync(id);
            return fruit == null ? NotFound() : Ok(fruit);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Fruit fruit)
        {
            var created = await _service.CreateAsync(fruit);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Fruit fruit)
        {
            if (id != fruit.Id) return BadRequest();
            var updated = await _service.UpdateAsync(fruit);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
