using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalisisProyecto.Models.DB;

namespace AnalisisProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomSchedulesController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public ClassroomSchedulesController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/ClassroomSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassroomSchedule>>> GetClassroomSchedules()
        {
          if (_context.ClassroomSchedules == null)
          {
              return NotFound();
          }
            return await _context.ClassroomSchedules.ToListAsync();
        }

        // GET: api/ClassroomSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassroomSchedule>> GetClassroomSchedule(int id)
        {
          if (_context.ClassroomSchedules == null)
          {
              return NotFound();
          }
            var classroomSchedule = await _context.ClassroomSchedules.FindAsync(id);

            if (classroomSchedule == null)
            {
                return NotFound();
            }

            return classroomSchedule;
        }

        // PUT: api/ClassroomSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassroomSchedule(int id, ClassroomSchedule classroomSchedule)
        {
            if (id != classroomSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(classroomSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomScheduleExists(id))
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

        // POST: api/ClassroomSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassroomSchedule>> PostClassroomSchedule(ClassroomSchedule classroomSchedule)
        {
          if (_context.ClassroomSchedules == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.ClassroomSchedules'  is null.");
          }
            _context.ClassroomSchedules.Add(classroomSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassroomSchedule", new { id = classroomSchedule.Id }, classroomSchedule);
        }

        // DELETE: api/ClassroomSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroomSchedule(int id)
        {
            if (_context.ClassroomSchedules == null)
            {
                return NotFound();
            }
            var classroomSchedule = await _context.ClassroomSchedules.FindAsync(id);
            if (classroomSchedule == null)
            {
                return NotFound();
            }

            _context.ClassroomSchedules.Remove(classroomSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassroomScheduleExists(int id)
        {
            return (_context.ClassroomSchedules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
