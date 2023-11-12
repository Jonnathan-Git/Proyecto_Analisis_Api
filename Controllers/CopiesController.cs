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
    public class CopiesController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public CopiesController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/Copies
        [HttpGet]
        [Route("getAll/{id}")]
        public async Task<ActionResult<IEnumerable<Copy>>> GetCopies(int id)
        {
          if (_context.Copies == null)
          {
              return NotFound();
          }
            return await _context.Copies
                .Where(c => c.IdTitles == id)
                .ToListAsync();
        }

        // GET: api/Copies/5
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<ActionResult<Copy>> GetCopy(int id)
        {
          if (_context.Copies == null)
          {
              return NotFound();
          }
            var copy = await _context.Copies.FindAsync(id);

            if (copy == null)
            {
                return NotFound();
            }

            return copy;
        }

        // PUT: api/Copies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Copy>> PutCopy(Copy copy) {
            if (_context.Copies == null) {
                return Problem("Entity set 'AnalisisProyectoContext.Copies'  is null.");
            }
            _context.Entry(copy).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(copy);
        }

        // POST: api/Copies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Copy>> PostCopy(Copy copy)
        {
          if (_context.Copies == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.Copies'  is null.");
          }
            _context.Copies.Add(copy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCopy", new { id = copy.Id }, copy);
        }

        // DELETE: api/Copies/5
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteCopy(int id)
        {
            if (_context.Copies == null)
            {
                return NotFound();
            }
            var copy = await _context.Copies.FindAsync(id);
            copy.Active = false;
            if (copy == null)
            {
                return NotFound();
            }

            _context.Entry(copy).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CopyExists(int id)
        {
            return (_context.Copies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
