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
    public class StudyRoomSchedulesController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public StudyRoomSchedulesController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/StudyRoomSchedules
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<StudyRoomSchedule>>> GetStudyRoomSchedules()
        {
          if (_context.StudyRoomSchedules == null)
          {
              return NotFound();
          }
            return await _context.StudyRoomSchedules.ToListAsync();
        }

        // GET: api/StudyRoomSchedules/5
        [HttpGet()]
        [Route("getStudyRoomSchedule/{id}")]
        public async Task<ActionResult<StudyRoomSchedule>> GetStudyRoomSchedule(int id)
        {
          if (_context.StudyRoomSchedules == null)
          {
              return NotFound();
          }
            var studyRoomSchedule = await _context.StudyRoomSchedules.FindAsync(id);

            if (studyRoomSchedule == null)
            {
                return NotFound();
            }

            return studyRoomSchedule;
        }

        // PUT: api/StudyRoomSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        [Route("updateStudyRoomSchedule/{id}")]
        public async Task<IActionResult> PutStudyRoomSchedule(int id, StudyRoomSchedule studyRoomSchedule)
        {
            if (id != studyRoomSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(studyRoomSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyRoomScheduleExists(id))
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

        // POST: api/StudyRoomSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("createStudyRoomSchedule")]
        public async Task<ActionResult<StudyRoomSchedule>> PostStudyRoomSchedule(StudyRoomSchedule studyRoomSchedule)
        {
          if (_context.StudyRoomSchedules == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.StudyRoomSchedules'  is null.");
          }
            _context.StudyRoomSchedules.Add(studyRoomSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudyRoomSchedule", new { id = studyRoomSchedule.Id }, studyRoomSchedule);
        }

        // DELETE: api/StudyRoomSchedules/5
        [HttpDelete()]
        [Route("deleteStudyRoomSchedule/{id}")]
        public async Task<IActionResult> DeleteStudyRoomSchedule(int id)
        {
            if (_context.StudyRoomSchedules == null)
            {
                return NotFound();
            }
            var studyRoomSchedule = await _context.StudyRoomSchedules.FindAsync(id);
            if (studyRoomSchedule == null)
            {
                return NotFound();
            }

            _context.StudyRoomSchedules.Remove(studyRoomSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudyRoomScheduleExists(int id)
        {
            return (_context.StudyRoomSchedules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
