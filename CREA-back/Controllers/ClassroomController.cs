using CREA_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CREA_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomController : ControllerBase
    {
        private readonly ClassroomContext _context;

        public ClassroomController(ClassroomContext context)
        {
            _context = context;
        }

        // GET: api/Classroom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
        {
            return await _context.Classrooms.ToListAsync();
        }

        // POST: api/Classroom
        [HttpPost]
        public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
        {
            _context.Classrooms.Add(classroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassrooms), new { code = classroom.Code }, classroom);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> PutClassroom(string code, Classroom classroom)
        {
            if (code != classroom.Code)
            {
                return BadRequest();
            }

            _context.Entry(classroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Classrooms.Any(e => e.Code == code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteClassroom(string code)
        {
            var classroom = await _context.Classrooms.FindAsync(code);
            if (classroom == null)
            {
                return NotFound();
            }

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
