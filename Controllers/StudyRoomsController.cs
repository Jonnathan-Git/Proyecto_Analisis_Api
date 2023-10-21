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
    public class StudyRoomsController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public StudyRoomsController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/StudyRooms
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<StudyRoom>>> GetStudyRooms()
        {
          if (_context.StudyRooms == null)
          {
              return NotFound();
          }
            return await _context.StudyRooms.ToListAsync();
        }

        // GET: api/StudyRooms/5
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<ActionResult<StudyRoom>> GetStudyRoom(int id)
        {
          if (_context.StudyRooms == null)
          {
              return NotFound();
          }
            var studyRoom = await _context.StudyRooms.FindAsync(id);

            if (studyRoom == null)
            {
                return NotFound();
            }

            return studyRoom;
        }

        // PUT: api/StudyRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudyRoom(int id, StudyRoom studyRoom)
        {
            if (id != studyRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(studyRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyRoomExists(id))
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

        // POST: api/StudyRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudyRoom>> PostStudyRoom(StudyRoom studyRoom)
        {
          if (_context.StudyRooms == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.StudyRooms'  is null.");
          }
            _context.StudyRooms.Add(studyRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudyRoom", new { id = studyRoom.Id }, studyRoom);
        }

        // DELETE: api/StudyRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudyRoom(int id)
        {
            if (_context.StudyRooms == null)
            {
                return NotFound();
            }
            var studyRoom = await _context.StudyRooms.FindAsync(id);
            if (studyRoom == null)
            {
                return NotFound();
            }

            _context.StudyRooms.Remove(studyRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudyRoomExists(int id)
        {
            return (_context.StudyRooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
