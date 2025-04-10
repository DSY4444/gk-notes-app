using Microsoft.AspNetCore.Mvc;
using KnowledgePointsApp.Models;
using KnowledgePointsApp.Data;
using KnowledgePointsApp.Dtos;

namespace KnowledgePointsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KnowledgePointsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KnowledgePointsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateKnowledgePointDto dto)
        {
            var point = new KnowledgePoint
            {
                Title = dto.Title,
                Description = dto.Description,
                Tags = dto.Tags
            };

            _context.KnowledgePoints.Add(point);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = point.Id }, point);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var point = await _context.KnowledgePoints.FindAsync(id);
            return point == null ? NotFound() : Ok(point);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.KnowledgePoints.ToList());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, KnowledgePoint updatedPoint)
        {
            var point = await _context.KnowledgePoints.FindAsync(id);
            if (point == null) return NotFound();

            point.Title = updatedPoint.Title;
            point.Description = updatedPoint.Description;
            point.Tags = updatedPoint.Tags;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var point = await _context.KnowledgePoints.FindAsync(id);
            if (point == null) return NotFound();

            _context.KnowledgePoints.Remove(point);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}