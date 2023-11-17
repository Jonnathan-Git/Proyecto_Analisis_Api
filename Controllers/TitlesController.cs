using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalisisProyecto.Models.DB;

namespace AnalisisProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public TitlesController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/Titles
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<Title>>> GetTitles()
        {
          if (_context.Titles == null)
          {
              return NotFound();
          }
            return await _context.Titles.ToListAsync();
        }

        // GET: api/Titles/5
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<ActionResult<Title>> GetTitle(int id)
        {
          if (_context.Titles == null)
          {
              return NotFound();
          }
            var title = await _context.Titles.FindAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return title;
        }

        // PUT: api/Titles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Title>> PutTitle(Title title)
        {
            if (_context.Titles == null) {
                return Problem("Entity set 'AnalisisProyectoContext.Titles'  is null.");
            }
            _context.Entry(title).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitle", new { id = title.Id }, title);
        }

        // POST: api/Titles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Title>> PostTitle(Title title)
        {
          if (_context.Titles == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.Titles'  is null.");
          }
            _context.Titles.Add(title);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitle", new { id = title.Id }, title);
        }

        // DELETE: api/Titles/5
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteTitle(int id)
        {
            if (_context.Titles == null)
            {
                return NotFound();
            }
            var title = await _context.Titles.FindAsync(id);
            title.Active = false;
            if (title == null)
            {
                return NotFound();
            }

            _context.Entry(title).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TitleExists(int id)
        {
            return (_context.Titles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
